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
        protected Dictionary<string, float> _Status;
        public Dictionary<string, float> Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                UpdateReadings();
            }
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

            lblCurrentTemp.Text = Status["Thermometer" + ThermoInt].ToString("N1");

            if (Status["TempAlarmActive"] > 0 && Status["WhichThermoAlarm"] == ThermoInt)
            {
                lblCurrentTemp.Text = lblCurrentTemp.Text + "!!!!";
                lblCurrentTemp.ForeColor = System.Drawing.Color.Red;
            }


            btnTempHighAlarm.Text = Status["ThermometerHighAlarm" + ThermoInt].ToString("N1");
            btnTempLowAlarm.Text = Status["ThermometerLowAlarm" + ThermoInt].ToString("N1");
        }
        protected void btnUpdateAlarms_OnClick(object sender, EventArgs e)
        {
         //   BrewControl.ClearAlarms(Thermometer);
            //btnTempHighAlarm.Text = Convert.ToString(257);
            //btnTempLowAlarm.Text = Convert.ToString(14);
            pnlSetAlarm.Visible = false;




            float alarm;
            if (float.TryParse(tbAlarm.Text, out alarm) == false)
            {
                return;
            }

            if (alarm >= 15 && alarm <= 250 && !string.IsNullOrEmpty(tbAlarm.Text))
            {
                if (hfWhichAlarm.Value == "High")
                {
                    BrewControl.SetHighTempAlarm(Thermometer, alarm);
                    btnTempHighAlarm.Text = Convert.ToString(alarm);
                }
                else
                {
                    BrewControl.SetLowTempAlarm(Thermometer, alarm);
                    btnTempLowAlarm.Text = Convert.ToString(alarm);
                }
            }


        }
        protected void btnTempHighAlarm_OnClick(object sender, EventArgs e)
        {
            pnlSetAlarm.Visible = true;
            lblAlarmTitle.Text = Name + ": High Temperature Alarm";
            hfWhichAlarm.Value = "High";
        }
        protected void btnTempLowAlarm_OnClick(object sender, EventArgs e)
        {
            pnlSetAlarm.Visible = true;
            lblAlarmTitle.Text = Name + ": Low Temperature Alarm";
            hfWhichAlarm.Value = "Low";
        }

        protected void btnCurrentTemp_OnClick(object sender, EventArgs e)
        {
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