using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace BrewduinoCatalogLib
{
    public class BrewController
    {

        public enum ThermometersName
        {
            MashTun,
            Kettle,
            HLT,
            RIMS,
        }
        private IArduinoSelfHost _Arduino;
        public IArduinoSelfHost Arduino
        {
            get { return _Arduino; }
            set { _Arduino = value; }
        }
        public BrewController()
        {
            var binding = new BasicHttpBinding();
            //var address = new EndpointAddress("http://localhost:8080/SerialSwitch");
            var address = new EndpointAddress("http://192.168.0.16:8080/SerialSwitch");
            Arduino = new ArduinoSelfHostClient(binding, address);
            
        }
        public BrewController(IArduinoSelfHost inArduino)
        {
            Arduino = inArduino;
        }
       
        public void SetHighTempAlarm(ThermometersName whichThermo, string highTemp)
        {
            string command = ((int)whichThermo).ToString() + "," + highTemp;
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetTempAlarmHigh, command);
        }
        public void SetLowTempAlarm(ThermometersName whichThermo, string lowTemp)
        {
            string command = ((int)whichThermo).ToString() + "," + lowTemp;
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetTempAlarmLow, command);
        }
        public void SetTimer(string minutes)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetTimer, minutes);
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.ReturnStatus,"");
        }
        public string GetHighTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, string> response = Arduino.GetStatus();

            string key = "ThermometerHighAlarm" + (int)whichThermo;
            return response[key];
        }
        public string GetLowTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, string> response = Arduino.GetStatus();

            string key = "ThermometerLowAlarm" + (int)whichThermo;
            return response[key];
        }
        public string GetTemps(ThermometersName whichThermo)
        {
            Dictionary<string, string> response = Arduino.GetStatus();


            int index = (int)whichThermo;
            string key = "Thermometer" + (int)whichThermo;
            return response[key];
        }
        public Dictionary<string, string> GetStatus()
        {
            Dictionary<string, string> response = Arduino.GetStatus();

            return response;
        }
        public void ClearAlarms(ThermometersName whichThermo)
        {
            string command = ((int)whichThermo).ToString();
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.ClearTempAlarms, command);
        }
        public void ResetAlarm()
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.ResetAlarm, "");
        }

        public void SetPIDSetPoint(string setPoint)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetPIDSetPoint, setPoint);
        }
        public void SetPIDWindowSize(string windowSize)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetPIDWindowSize, windowSize);
        }
        public void SetPIDKp(string kp)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetPIDKp, kp);
        }
        public void SetPIDKi(string ki)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetPIDKi, ki);
        }
        public void SetPIDKd(string kd)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetPIDKd, kd);
        }
        public void TurnOnRims(int rimsOn)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.TurnOnRims, rimsOn.ToString());
        }
        public void TurnOnPumps(int pumpsOn)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.TurnOnPump, pumpsOn.ToString());
        }
        public void TurnOnAux(int auxOn)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.TurnOnAux, auxOn.ToString());
        }
       
    }
}