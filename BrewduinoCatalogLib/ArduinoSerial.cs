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
        public Dictionary<string, string> SendCommandWithResponse(ArduinoCommands.CommandTypes cmd, string text)
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
                    return new Dictionary<string, string>();
                }
                if (response.ToString().Contains(";"))
                    break;

            }

            //Close();

            return parseVaribles(response.ToString());
        }

        public string SendCommandWithDebugResponse(ArduinoCommands.CommandTypes cmd, string text)
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
                    return string.Empty;
                }
                if (response.ToString().Contains(";"))
                    break;

            }
          

            return response.ToString();
        }

       

        public Dictionary<string, string> parseVaribles(string response)
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

            Dictionary<string, string> dict = new Dictionary<string, string>();

            string[] pairs = message.Split(',');

            foreach (string textValue in pairs)
            {
                string[] pair = textValue.Split('|');
               
                dict.Add(pair[0], pair[1]);
            }


            return dict;
        }

        public Dictionary<string, string> GetStatus()
        {
            return new Dictionary<string,string>();
        }
        public void UpdateStatus()
        {
        }
        public string GetRawStatus()
        { return string.Empty; }

    }

}
