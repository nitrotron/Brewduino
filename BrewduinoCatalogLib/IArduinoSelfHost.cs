using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace BrewduinoCatalogLib
{
    [ServiceContract]
    public interface IArduinoSelfHost
    {
        [OperationContract]
        string GetRawStatus();
        [OperationContract]
        Dictionary<string, string> GetStatus();
        [OperationContract]
        void SendCommand(int arduinoCommands, string text);
        //[OperationContract]
        //Dictionary<string, string> SendCommandWithResponse(ArduinoCommands.CommandTypes cmd, string text);
        [OperationContract]
        void UpdateStatus();
    }
}
