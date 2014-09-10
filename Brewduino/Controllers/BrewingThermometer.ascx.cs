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
        protected Dictionary<string, string> _Status;
        public Dictionary<string, string> Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                //UpdateReadings();
            }
        }
        private bool CurrentTemperatureExists
        {
            get
            {
                if (Status != null && Status.ContainsKey("Thermometer" + ThermoInt))
                    return true;
                else
                    return false;
            }
        }


        #endregion
        protected void Page_Init()
        {
            DateTime myDate = DateTime.Now.AddHours(-5);

            // AnnotatedTimeline Test
            List<GoogleChartsNGraphsControls.TimelineEvent> evts = new List<GoogleChartsNGraphsControls.TimelineEvent>();
            float temperature = 55;
            Random ran = new Random();
            for (int i = 0; i < 100; i++)
            {
                float adder = ran.Next(-20, 100);
                //decimal.TryParse(ran.Next(100).ToString(), out adder);
                temperature += adder / (float)25.0;
                if (temperature > 211) temperature = 211;
                if (temperature < 55) temperature = 55;
                evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Temp", myDate, (decimal)temperature));
                myDate = myDate.AddMinutes(5);
            }
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 2), 14045));
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 3), 55022));
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 4), 75284));
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 5), 41476));
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 6), 33322));

            //this.GVAnnotatedTimeline1.ChartData(evts.ToArray());
            this.GVAnnotatedTimeline2.ChartData(evts.Where(d => d.EventCategory == "Temp").ToArray());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = Name;
                UpdateReadings();
            }
        }

        protected void UpdateChart()
        {
            DateTime myDate = DateTime.Now.AddHours(-5);

            // AnnotatedTimeline Test
            List<GoogleChartsNGraphsControls.TimelineEvent> evts = new List<GoogleChartsNGraphsControls.TimelineEvent>();
            float temperature = 55;
            Random ran = new Random();
            for (int i = 0; i < 100; i++)
            {
                float adder = ran.Next(-20, 100);
                //decimal.TryParse(ran.Next(100).ToString(), out adder);
                temperature += adder / (float)25.0;
                if (temperature > 211) temperature = 211;
                if (temperature < 55) temperature = 55;
                evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Temp", myDate, (decimal)temperature));
                myDate = myDate.AddMinutes(5);
            }
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 2), 14045));
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 3), 55022));
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 4), 75284));
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 5), 41476));
            //evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 6), 33322));

            //this.GVAnnotatedTimeline1.ChartData(evts.ToArray());
            this.GVAnnotatedTimeline2.ChartData(evts.Where(d => d.EventCategory == "Temp").ToArray());
        }

        public void UpdateReadings()
        {
            //no need to continue if this thermometer doesn't exist
            if (!CurrentTemperatureExists)
            {
                lblCurrentTemp.Text = "00.0";
                btnTempHighAlarm.Text = "00.0";
                btnTempLowAlarm.Text = "00.0";
                lblCurrentTemp.Text = "--.-";
                btnTempHighAlarm.Text = "--.-";
                btnTempLowAlarm.Text = "--.-";
                return;
            }
            lblCurrentTemp.Text = String.Format("{0:N1}", Status["Thermometer" + ThermoInt]);

            bool tempAlarmActive = false;
            bool.TryParse(Status["TempAlarmActive"], out tempAlarmActive);
            int whichThermoAlarm = 9999;
            int.TryParse(Status["WhichThermoAlarm"], out whichThermoAlarm);

            if (tempAlarmActive && whichThermoAlarm == ThermoInt)
            {
                lblCurrentTemp.Text = lblCurrentTemp.Text + "!!!!";
                lblCurrentTemp.ForeColor = System.Drawing.Color.Red;
            }

            decimal temp;
            decimal.TryParse(Status["ThermometerHighAlarm" + ThermoInt], out temp);
            temp = decimal.Round(temp, 1);
            btnTempHighAlarm.Text = temp.ToString();
            //btnTempHighAlarm.Text = temp.ToString();
            decimal.TryParse(Status["ThermometerLowAlarm" + ThermoInt], out temp);
            temp = decimal.Round(temp, 1);
            //btnTempLowAlarm.Text = temp.ToString();
            btnTempLowAlarm.Text = temp.ToString();

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
                    BrewControl.SetHighTempAlarm(Thermometer, alarm.ToString());
                    btnTempHighAlarm.Text = Convert.ToString(alarm);
                }
                else
                {
                    BrewControl.SetLowTempAlarm(Thermometer, alarm.ToString());
                    btnTempLowAlarm.Text = Convert.ToString(alarm);
                }
            }


        }
        protected void btnCancelAlarms_OnClick(object sender, EventArgs e)
        {
            pnlSetAlarm.Visible = false;
        }
        protected void btnTempHighAlarm_OnClick(object sender, EventArgs e)
        {
            //no need to continue if this thermometer doesn't exist
            if (!CurrentTemperatureExists)
                return;

            pnlSetAlarm.Visible = true;
            lblAlarmTitle.Text = Name + ": High Temperature Alarm";
            hfWhichAlarm.Value = "High";
            decimal temp;
            decimal.TryParse(Status["ThermometerHighAlarm" + ThermoInt], out temp);
            temp = decimal.Round(temp, 1);
            tbAlarm.Text = temp.ToString();

            //tbAlarm.Text =  tbAlarm.Text.Remove(tbAlarm.Text.IndexOf('.')+2);
        }
        protected void btnTempLowAlarm_OnClick(object sender, EventArgs e)
        {
            //no need to continue if this thermometer doesn't exist
            if (!CurrentTemperatureExists)
                return;
            pnlSetAlarm.Visible = true;
            lblAlarmTitle.Text = Name + ": Low Temperature Alarm";
            hfWhichAlarm.Value = "Low";
            decimal temp;
            decimal.TryParse(Status["ThermometerLowAlarm" + ThermoInt], out temp);
            temp = decimal.Round(temp, 1);
            tbAlarm.Text = temp.ToString();
        }

        protected void btnCurrentTemp_OnClick(object sender, EventArgs e)
        {
            //no need to continue if this thermometer doesn't exist
            if (!CurrentTemperatureExists)
                return;
            pnlTempGraph.Style["display"] = "block";
            UpdateChart();
        }
        protected void btnUpdateRims_Click(object sender, EventArgs e)
        {
            BrewControl.SetPIDSetPoint(tbSetPoint.Text);
            BrewControl.SetPIDWindowSize(tbWindowSize.Text);
            BrewControl.SetPIDKd(tbKd.Text);
            BrewControl.SetPIDKi(tbKi.Text);
            BrewControl.SetPIDKp(tbKp.Text);

        }
        protected void btnUpdateRimsCancel_Click(object sender, EventArgs e)
        {
            /* Do nothing. Just want a call back that will hide the div. */
        }


        public void ResetAlarm()
        {
            //no need to continue if this thermometer doesn't exist
            if (!CurrentTemperatureExists)
                return;
            int temperature;
            int.TryParse(Status["Thermometer" + ThermoInt], out temperature);
            int thermometerHighAlarm;
            int.TryParse(Status["ThermometerHighAlarm" + ThermoInt], out thermometerHighAlarm);
            int thermometerLowAlarm;
            int.TryParse(Status["ThermometerLowAlarm" + ThermoInt], out thermometerLowAlarm);

            if (temperature > thermometerHighAlarm)
            {
                BrewControl.SetHighTempAlarm(Thermometer, "257");
            }
            else if (temperature < thermometerLowAlarm)
            {
                BrewControl.SetLowTempAlarm(Thermometer, "14");
            }
            else
                BrewControl.ClearAlarms(Thermometer);
        }
        public void ShowRimsPanel(bool showPanel)
        {
            pnlRimsButton.Visible = showPanel;
            tbKp.Text = Status["Kp"];
            tbKi.Text = Status["Ki"];
            tbKd.Text = Status["Kd"];
            tbSetPoint.Text = Status["SetPoint"];
            tbWindowSize.Text = Status["WindowSize"];


        }
    }
}