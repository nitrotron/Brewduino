using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        private ArduinoSelfHostClient _Arduino;
        public ArduinoSelfHostClient Arduino
        {
            get { return _Arduino; }
            set { _Arduino = value; }
        }
        public BrewController(ArduinoSelfHostClient inArduino)
        {
            Arduino = inArduino;
        }
       
        public void SetHighTempAlarm(ThermometersName whichThermo, decimal highTemp)
        {
            string command = ((int)whichThermo).ToString() + "," + highTemp.ToString();
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetTempAlarmHigh, command);
        }
        public void SetLowTempAlarm(ThermometersName whichThermo, decimal lowTemp)
        {
            string command = ((int)whichThermo).ToString() + "," + lowTemp.ToString();
            Arduino.SendCommand((int)ArduinoCommands.CommandTypes.SetTempAlarmLow, command);
        }
        public decimal GetHighTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, decimal> response = Arduino.GetStatus();

            string key = "ThermometerHighAlarm" + (int)whichThermo;
            return response[key];
        }
        public decimal GetLowTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, decimal> response = Arduino.GetStatus();

            string key = "ThermometerLowAlarm" + (int)whichThermo;
            return response[key];
        }
        public decimal GetTemps(ThermometersName whichThermo)
        {
            Dictionary<string, decimal> response = Arduino.GetStatus();


            int index = (int)whichThermo;
            string key = "Thermometer" + (int)whichThermo;
            return response[key];
        }
        public Dictionary<string, decimal> GetStatus()
        {
            Dictionary<string, decimal> response = Arduino.GetStatus();

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