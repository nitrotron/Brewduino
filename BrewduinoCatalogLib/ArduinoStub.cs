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


        public Dictionary<string, float> GetStatus()
        {
            Dictionary<string, float> returnDict = new Dictionary<string, float>();

            returnDict["Thermometer0"] = 150.2F;
            returnDict["Thermometer1"] = 82.9F;
            returnDict["Thermometer2"] = 202.3F;

            returnDict["TempAlarmActive"] = 1;
            returnDict["TimerAlarmActive"] = 0;

            returnDict["ThermometerHighAlarm0"] = 275.0F;
            returnDict["ThermometerHighAlarm1"] = 80.0F;
            returnDict["ThermometerHighAlarm2"] = 275.0F;
            returnDict["ThermometerLowAlarm0"] = -10.0F;
            returnDict["ThermometerLowAlarm1"] = -10.0F;
            returnDict["ThermometerLowAlarm2"] = -10.0F;
            returnDict["WhichThermoAlarm"] = (int)BrewController.ThermometersName.Kettle;
            returnDict["TimersNotAllocated"] = 3;
            returnDict["TotalTimers"] = 6;

            

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
