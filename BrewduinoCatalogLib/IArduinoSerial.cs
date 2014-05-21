using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewduinoCatalogLib
{
    public interface IArduinoSerial
    {

        void SendCommand(ArduinoCommands.CommandTypes cmd, string text);
        Dictionary<string, decimal> SendCommandWithResponse(ArduinoCommands.CommandTypes cmd, string text);
        Dictionary<string, decimal> GetStatus();
        void UpdateStatus();
        string GetRawStatus();
    }
}
