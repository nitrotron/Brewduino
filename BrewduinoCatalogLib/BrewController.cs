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

        public void setHighTempAlarm(ThermometersName whichThermo, int highTemp)
        {
            string command = whichThermo.ToString() + "," + highTemp.ToString();
            Arduino.SendCommand(ArduinoCommands.CommandTypes.SetTempAlarmHigh, command);
        }
        public void setLowTempAlarm(ThermometersName whichThermo, int lowTemp)
        {
            string command = whichThermo.ToString() + "," + lowTemp.ToString();
            Arduino.SendCommand(ArduinoCommands.CommandTypes.SetTempAlarmLow, command);
        }
        public int getHighTempAlarm(ThermometersName whichThermo)
        {
            Dictionary<string, int> response = Arduino.SendCommandWithResponse(ArduinoCommands.CommandTypes.GetTempAlarms, "");
            //need to fix this.
            return Convert.ToInt16(response["TempHigh"]);
        }
    }
}