using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;
using System.ServiceModel;
using System.Media;
using System.ComponentModel;
using Brewduino.Controllers;

namespace Brewduino.Pages
{
    public partial class RimsPanel : System.Web.UI.Page
    {
        //protected ArduinoSerial mySerial = new ArduinoSerial();
        protected IArduinoSelfHost Arduino;
        protected BrewController BrewControl;
        protected Dictionary<string, string> CurrentStatus;
        protected List<BrewingThermometer> thermometers = new List<BrewingThermometer>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var binding = new BasicHttpBinding();
            //var address = new EndpointAddress("http://localhost:8080/SerialSwitch");
            var address = new EndpointAddress("http://192.168.0.21:8080/SerialSwitch");
            Arduino = new ArduinoSelfHostClient(binding, address);
            Arduino = new ArduinoStub(); //This in there so I can work on the skin.
            BrewControl = new BrewController(Arduino);
            
            

            CurrentStatus = BrewControl.GetStatus();
            btRims.Thermometer = BrewController.ThermometersName.RIMS;
            btRims.Name = "RIMS";
            btRims.BrewControl = BrewControl;
            btRims.Status = CurrentStatus;
            if (!Page.IsPostBack)
                btRims.ShowRimsPanel(true);
            thermometers.Add(btRims);

            btMash.Thermometer = BrewController.ThermometersName.MashTun;
            btMash.Name = "Mash Tun";
            btMash.BrewControl = BrewControl;
            btMash.Status = CurrentStatus;
            thermometers.Add(btMash);

            btKettle.Thermometer = BrewController.ThermometersName.Kettle;
            btKettle.Name = "Kettle";
            btKettle.BrewControl = BrewControl;
            btKettle.Status = CurrentStatus;
            thermometers.Add(btKettle);

            btHLT.Thermometer = BrewController.ThermometersName.HLT;
            btHLT.Name = "HLT/Kettle 2";
            btHLT.BrewControl = BrewControl;
            btHLT.Status = CurrentStatus;
            thermometers.Add(btHLT);


            cdtTimer.BrewControl = BrewControl;
            cdtTimer.Status = CurrentStatus;

            bool tempAlarmActive = (CurrentStatus["TempAlarmActive"] == "1") ? true : false;
            bool timerAlarmActive = (CurrentStatus["TimerAlarmActive"] == "1") ? true : false;

            if (tempAlarmActive || timerAlarmActive)
            {
                //lblMainAlarm.Text = "We have an alarm";
                btnResetAlarm.Checked = true;
                if (cdtTimer.GetchkSoundAlarm())
                    soundAlarm();
            }



            //Response.AppendHeader("Refresh", 5 + "; URL=RimsPanel.aspx");
            tmrRefreshStatus.Interval = 15000;
            tmrRefreshStatus.Enabled = true;

            if (!Page.IsPostBack)
                RefreshButtons();

            lblLastUpdate.Text = "Last Update " + DateTime.Now.ToLongTimeString();
            BindDebugDataList();

        }

        private void BindDebugDataList()
        {
            dlDebug.DataSource = CurrentStatus;
            dlDebug.DataBind();
        }

        private void RefreshButtons()
        {
            chkRimsOn.Checked = (CurrentStatus["RimsEnable"] == "1") ? true : false;
            chAuxPower.Checked = (CurrentStatus["AuxOn"] == "1") ? true : false;
            chPumpOn.Checked = (CurrentStatus["PumpOn"] == "1") ? true : false;
        }


        protected void btnResetAlarm_OnClick(object sender, EventArgs e)
        {
            bool tempAlarmActive = (CurrentStatus["TempAlarmActive"] == "1") ? true : false;

            if (tempAlarmActive)
            {
                int whichThermoAlarm = 9999;
                int.TryParse(CurrentStatus["WhichThermoAlarm"], out whichThermoAlarm);
                foreach (BrewingThermometer bt in thermometers)
                {
                    if (whichThermoAlarm == bt.ThermoInt)
                    {
                        bt.ResetAlarm();
                    }
                }
                //if (whichThermoAlarm == (int)BrewController.ThermometersName.RIMS)
                //{
                //    btRims.ResetAlarm();
                //}
                //else if (whichThermoAlarm == (int)BrewController.ThermometersName.MashTun)
                //{
                //    btMash.ResetAlarm();
                //}
                //else if (whichThermoAlarm == (int)BrewController.ThermometersName.Kettle)
                //{
                //    btKettle.ResetAlarm();
                //}
                //else if (whichThermoAlarm == (int)BrewController.ThermometersName.HLT)
                //{
                //    btHLT.ResetAlarm();
                //}
            }
            //if (CurrentStatus["TimerAlarmActive"] > 0)
            {
                cdtTimer.ResetAlarm();
            }
            //lblMainAlarm.Text = string.Empty;

            BrewControl.ResetAlarm();
            btnResetAlarm.Checked = false;

        }

        protected void tmrRefreshStatus_Tick(object sender, EventArgs e)
        {
            // do nothing. This post back should be enough
            CurrentStatus = BrewControl.GetStatus();

            foreach(BrewingThermometer bt in thermometers)
            {
                bt.Status = CurrentStatus;
                bt.UpdateReadings();
            }
            //btRims.Status = CurrentStatus;
            //btKettle.Status = CurrentStatus;
            //btMash.Status = CurrentStatus;
            //btHLT.Status = CurrentStatus;
            cdtTimer.Status = CurrentStatus;

            //btRims.UpdateReadings();
            //btKettle.UpdateReadings();
            //btMash.UpdateReadings();
            //btHLT.UpdateReadings();
            cdtTimer.UpdateReadings();
            RefreshButtons();

        }

        protected void chkRimsOn_CheckedChanged(object sender, EventArgs e)
        {
            BrewControl.TurnOnRims((chkRimsOn.Checked == true) ? 1 : 0);
        }

        protected void chPumpOn_CheckedChanged(object sender, EventArgs e)
        {
            BrewControl.TurnOnPumps((chPumpOn.Checked == true) ? 1 : 0);
        }

        protected void chAuxPower_CheckedChanged(object sender, EventArgs e)
        {
            BrewControl.TurnOnAux((chAuxPower.Checked == true) ? 1 : 0);
        }

        protected void lbEnableDebug_OnClick(object sender, EventArgs e)
        {
            if (!pnlDebug.Visible)
            {
                pnlDebug.Visible = true;
                lbEnableDebug.Text = "Hide BruinoData";
            }
            else
            {
                pnlDebug.Visible = false;
                lbEnableDebug.Text = "Show BruinoData";
            }
        }

        private void soundAlarm()
        {

            SoundPlayer wavPlayer = new SoundPlayer();
            wavPlayer.SoundLocation = "C:/Users/jessica/Documents/GitHub/Brewduino/Brewduino/Sounds/ALARM.WAV";
            wavPlayer.LoadCompleted += new AsyncCompletedEventHandler(wavPlayer_LoadCompleted);
            wavPlayer.LoadAsync();

        }

        private void wavPlayer_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ((System.Media.SoundPlayer)sender).Play();
        }
    }
}