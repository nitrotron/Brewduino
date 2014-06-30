using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewduinoCatalogLib
{
    public class ArduinoStub : IArduinoSelfHost
    {


        public string GetRawStatus()
        {
            throw new NotImplementedException();
        }


        public Dictionary<string, string> GetStatus()
        {
            Dictionary<string, string> returnDict = new Dictionary<string, string>();

            returnDict["Thermometer0"] = "150.2";
            returnDict["Thermometer1"] = "82.9";
            returnDict["Thermometer2"] = "202.3";

            returnDict["TempAlarmActive"] = "1";
            returnDict["TimerAlarmActive"] = "0";

            returnDict["ThermometerHighAlarm0"] = "275.0";
            returnDict["ThermometerHighAlarm1"] = "80.0";
            returnDict["ThermometerHighAlarm2"] = "275.0";
            returnDict["ThermometerLowAlarm0"] = "-10.0";
            returnDict["ThermometerLowAlarm1"] = "-10.0";
            returnDict["ThermometerLowAlarm2"] = "-10.0";
            returnDict["WhichThermoAlarm"] = BrewController.ThermometersName.Kettle.ToString();
            returnDict["TimersNotAllocated"] = "3";
            returnDict["TotalTimers"] = "6";

            

            return returnDict;
        }

        public void SendCommand(int arduinoCommands, string text)
        {
            // do nothing
        }

        public void UpdateStatus()
        {
            // do nothing
        }
    }
}
