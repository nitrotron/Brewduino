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


            //this.PortName = "COM3";
            this.PortName = "/dev/ttyACM0";
            this.BaudRate = 9600;
            this.Parity = Parity.None;
            this.DataBits = 8;
            this.StopBits = StopBits.One;
            this.ReadTimeout = 5000;
            this.WriteTimeout = 500;


        }

        public void OpenPort()
        {
            if (!IsOpen) Open();
        }
        public void ClosePort()
        {
            Close();
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
                //if (!IsOpen) Open();
                // FIXTHIS there was a problem with the serial not being open
                WriteLine(sendCmd.ToString());
            }

        }
        public Dictionary<string, decimal> SendCommandWithResponse(ArduinoCommands.CommandTypes cmd, string text)
        {
            //if (!IsOpen) Open();
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
                    //Close();
                    return new Dictionary<string, decimal>();
                }
                if (response.ToString().Contains(";"))
                    break;

            }

            //Close();

            return parseVaribles(response.ToString());
        }

        public Dictionary<string, decimal> parseVaribles(string response)
        {
            string[] pStrings;
            string message;
            if (response.Contains(':'))
            {
                pStrings = response.Split(':');
                message = pStrings[1];
            }
            else
            {
                message = response;
            }

            if (message.Contains(';'))
            {
                pStrings = message.Split(';');
                message = pStrings[0];
            }

            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();

            string[] pairs = message.Split(',');

            foreach (string textValue in pairs)
            {
                string[] pair = textValue.Split('|');
                //string value = pair[1];
                decimal temp;
                decimal.TryParse(pair[1], out temp);
                //int temp = (int)Convert.ToDecimal(value);
                //dict.Add(pair[0], (int)Convert.ToInt32(pair[1]));
                dict.Add(pair[0], temp);
            }


            return dict;
        }
    }

}
