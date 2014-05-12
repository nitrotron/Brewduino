using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewduinoCatalogLib
{
    public class Thermometer
    {
        private int _Temperature;
        public int Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }

        private int _HighAlarm;
        public int HighAlarm
        {
            get { return _HighAlarm; }
            set { _HighAlarm = value; }
        }
        private int _LowAlarm;
        public int LowAlarm
        {
            get { return _LowAlarm; }
            set { _LowAlarm = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private bool _AlarmTriggered;
        public bool AlarmTriggered
        {
            get { return AlarmTriggered; }
            set { _AlarmTriggered = value; }
        }

    }
}
