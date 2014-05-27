using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;

namespace Brewduino.Controllers
{
    public partial class BrewingThermometer : System.Web.UI.UserControl
    {
        #region attributes
        protected BrewController _BrewControl;
        public BrewController BrewControl
        {
            get { return _BrewControl; }
            set { _BrewControl = value; }
        }
        protected BrewController.ThermometersName _Thermometer;
        public BrewController.ThermometersName Thermometer
        {
            get { return _Thermometer; }
            set { _Thermometer = value; }
        }
        public int ThermoInt
        {
            get { return (int)_Thermometer; }
        }

        protected string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        protected Dictionary<string, decimal> _Status;
        public Dictionary<string, decimal> Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = Name;
                UpdateReadings();
            }
        }

        protected void UpdateReadings()
        {
           
            lblCurrentTemp.Text = Status["Thermometer" + ThermoInt].ToString();

            if (Status["TempAlarmActive"] > 0 && Status["WhichThermoAlarm"] == ThermoInt)
            {
                lblCurrentTemp.Text = lblCurrentTemp.Text + "!!!!";
                lblCurrentTemp.ForeColor = System.Drawing.Color.Red;
            }

            lblHighAlarm.Text = Status["ThermometerHighAlarm" + ThermoInt].ToString();
            lblLowAlarm.Text = Status["ThermometerLowAlarm" + ThermoInt].ToString();
        }
        protected void btnUpdateAlarms_OnClick(object sender, EventArgs e)
        {
            BrewControl.ClearAlarms(Thermometer);
            lblHighAlarm.Text = Convert.ToString(257);
            lblLowAlarm.Text = Convert.ToString(14);

            decimal alarm = -999;
            decimal.TryParse(tbHighAlarm.Text, out alarm);
            if (alarm >= -10 && alarm <= 125 && !string.IsNullOrEmpty(tbHighAlarm.Text))
            {
                BrewControl.SetHighTempAlarm(Thermometer, alarm);
                lblHighAlarm.Text = Convert.ToString(alarm);
            }
            alarm = -999;
            decimal.TryParse(tbLowAlarm.Text, out alarm);
            if (alarm >= -10 && alarm <= 125 && !string.IsNullOrEmpty(tbLowAlarm.Text))
            {
                BrewControl.SetLowTempAlarm(Thermometer, alarm);
                lblLowAlarm.Text = Convert.ToString(alarm);
            }

            
        }


        public void ResetAlarm()
        {
            if (Status["Thermometer" + ThermoInt] > Status["ThermometerHighAlarm" + ThermoInt])
            {
                BrewControl.SetHighTempAlarm(Thermometer, 257);
            }
            else if (Status["Thermometer" + ThermoInt] < Status["ThermometerLowAlarm" + ThermoInt])
            {
                BrewControl.SetLowTempAlarm(Thermometer, 14);
            }
            else
                BrewControl.ClearAlarms(Thermometer);
        }
    }
}