using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Ports;
using System.Text;

namespace BrewduinoCatalogLib
{
    public class ArduinoSerial : SerialPort, IArduinoSerial
    {

        ArduinoInfo Arduino = new ArduinoInfo();



        public ArduinoSerial()
            : base()
        {


            this.PortName = "COM3";
            this.BaudRate = 9600;
            this.Parity = Parity.None;
            this.DataBits = 8;
            this.StopBits = StopBits.One;
            this.ReadTimeout = 5000;
            this.WriteTimeout = 500;


        }

        public void SendCommand(ArduinoCommands.CommandTypes cmd, string text)
        {
            StringBuilder sendCmd = new StringBuilder();

            sendCmd.Append((int)cmd);
            if (!string.IsNullOrEmpty(text))
                sendCmd.Append("," + text + ";");
            else
                sendCmd.Append(";");


            if (sendCmd != null && !String.IsNullOrEmpty(sendCmd.ToString()))
            {
                WriteLine(sendCmd.ToString());
            }

        }
        public Dictionary<string, int> SendCommandWithResponse(ArduinoCommands.CommandTypes cmd, string text)
        {
            if (!IsOpen) Open();
            SendCommand(cmd, text);
            StringBuilder response = new StringBuilder();

            while (true)
            {
                try
                {
                    response.Append(ReadLine());
                }
                catch
                {
                    Close();
                    return new Dictionary<string, int>();
                }
                if (response.ToString().Contains(";"))
                    break;

            }

            Close();

            return parseVaribles(response.ToString());
        }

        public Dictionary<string, int> parseVaribles(string response)
        {
            string[] pStrings;
            pStrings = response.Split(':');
            Dictionary<string, int> dict = new Dictionary<string, int>();

            string[] pairs = pStrings[1].Split(',');

            foreach (string textValue in pairs)
            {
                string[] pair = textValue.Split('|');
                dict.Add(pair[0], Convert.ToInt16(pair[1]));
            }


            return dict;
        }
    }

}
