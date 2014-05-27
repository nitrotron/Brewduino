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
        Dictionary<string, decimal> GetStatus();
        //[OperationContract]
        //void SendCommand(ArduinoCommands.CommandTypes cmd, string text);
        //[OperationContract]
        //Dictionary<string, decimal> SendCommandWithResponse(ArduinoCommands.CommandTypes cmd, string text);
        [OperationContract]
        void UpdateStatus();
    }
}
