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
        private IArduinoSerial _Arduino;
        public IArduinoSerial Arduino
        {
            get { return _Arduino; }
            set { _Arduino = value; }
        }
        public BrewController(IArduinoSerial inArduino)
        {
            Arduino = inArduino;
        }
        public void setArduinoSerial(IArduinoSerial inArduino)
        {
            Arduino = inArduino;
        }


        public void SetHighTempAlarm(ThermometersName whichThermo, decimal highTemp)
        {
            string command = ((int)whichThermo).ToString() + "," + highTemp.ToString();
            Arduino.SendCommand(ArduinoCommands.CommandTypes.SetTempAlarmHigh, command);
        }
        public void SetLowTempAlarm(ThermometersName whichThermo, decimal lowTemp)
        {
            string command = ((int)whichThermo).ToString() + "," + lowTemp.ToString();
            Arduino.SendCommand(ArduinoCommands.CommandTypes.SetTempAlarmLow, command);
        }
        public decimal GetHighTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, decimal> response = Arduino.SendCommandWithResponse(ArduinoCommands.CommandTypes.GetTempAlarms, "");

            string key = "ThermometerHighAlarm" + (int)whichThermo;
            return response[key];
        }
        public decimal GetLowTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, decimal> response = Arduino.SendCommandWithResponse(ArduinoCommands.CommandTypes.GetTempAlarms, "");

            string key = "ThermometerLowAlarm" + (int)whichThermo;
            return response[key];
        }
        public decimal GetTemps(ThermometersName whichThermo)
        {
            Dictionary<string, decimal> response = Arduino.SendCommandWithResponse(ArduinoCommands.CommandTypes.GetTemps, "");

            int index = (int)whichThermo;
            string key = "Thermometer" + (int)whichThermo;
            return response[key];
        }
        public Dictionary<string, decimal> GetStatus()
        {
            Dictionary<string, decimal> response = Arduino.SendCommandWithResponse(ArduinoCommands.CommandTypes.GetTemps, "");
            Dictionary<string, decimal> alarms = (Arduino.SendCommandWithResponse(ArduinoCommands.CommandTypes.GetTempAlarms, ""));
            foreach (var item in alarms)
            {
                if (response.ContainsKey(item.Key))
                    response[item.Key] = item.Value;
                else
                    response.Add(item.Key, item.Value);
            }
            return response;
        }
        public void ClearAlarms(ThermometersName whichThermo)
        {
            string command = ((int)whichThermo).ToString();
            Arduino.SendCommand(ArduinoCommands.CommandTypes.ClearTempAlarms, command);
        }
    }
}