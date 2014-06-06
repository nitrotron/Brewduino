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
            RIMS,
            Kettle,
            MashTun
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
       
        public void SetHighTempAlarm(ThermometersName whichThermo, float highTemp)
        {
            string command = ((int)whichThermo).ToString() + "," + highTemp.ToString();
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetTempAlarmHigh, command);
        }
        public void SetLowTempAlarm(ThermometersName whichThermo, float lowTemp)
        {
            string command = ((int)whichThermo).ToString() + "," + lowTemp.ToString();
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetTempAlarmLow, command);
        }
        public void SetTimer(float minutes)
        {
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetTimer, minutes.ToString());
        }
        public float GetHighTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, float> response = Arduino.GetStatus();

            string key = "ThermometerHighAlarm" + (int)whichThermo;
            return response[key];
        }
        public float GetLowTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, float> response = Arduino.GetStatus();

            string key = "ThermometerLowAlarm" + (int)whichThermo;
            return response[key];
        }
        public float GetTemps(ThermometersName whichThermo)
        {
            Dictionary<string, float> response = Arduino.GetStatus();


            int index = (int)whichThermo;
            string key = "Thermometer" + (int)whichThermo;
            return response[key];
        }
        public Dictionary<string, float> GetStatus()
        {
            Dictionary<string, float> response = Arduino.GetStatus();

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

       
    }
}