using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewduinoCatalogLib
{
    public class ArduinoInfo
    {
        List<Thermometer> thermometers = new List<Thermometer>
        {
            new Thermometer() { Name = "RIMS" },
            new Thermometer() { Name = "Kettle" },
            new Thermometer() { Name = "Mash Tun" }
        };
        private bool _AlarmTriggered;
        public bool AlarmTriggered
        {
            get { return _AlarmTriggered; }
            set { _AlarmTriggered = value; }
        }


        //public string parseVariables(string text, string value)
        //{
        //    if (text.Contains("ThermometerHighAlarm"))
        //    {

        //    }
        //}
    }
}
