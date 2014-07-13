using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;

namespace Brewduino.Controllers
{
    public partial class CountDownTimer : System.Web.UI.UserControl
    {
        protected BrewController _BrewControl;
        public BrewController BrewControl
        {
            get { return _BrewControl; }
            set { _BrewControl = value; }
        }
        protected Dictionary<string, string> _Status;
        public Dictionary<string, string> Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                UpdateReadings();
            }
        }

        private void UpdateReadings()
        {
            CultureInfo ci = new CultureInfo("en-US");
            int TimersNotAllocated;
            int.TryParse(Status["TimersNotAllocated"], out TimersNotAllocated);
            if (TimersNotAllocated > 0)
            {
                btnAddNewTimer.Enabled = true;
            }
            else
            {
                btnAddNewTimer.Enabled = false;
            }

            DateTime serverTimeStamp = new DateTime();
            TimeSpan timedifference = new TimeSpan(0);
            if (Status.ContainsKey("ServerTime"))
            {
                if (DateTime.TryParse(Status["ServerTime"].ToString(), out serverTimeStamp))
                {
                    timedifference = serverTimeStamp - DateTime.Now;
                }
            }

            //lets remove any that have expired
            //StripAlarms();


            List<DateTime> OnGoingAlarms = ParseAlarms();

            string[] timerStrArray = hfPresentTimerList.Value.Split(',');
            StringBuilder updateHF = new StringBuilder();

            TimeSpan fudgeFactor = new TimeSpan(0, 0, 45);

            foreach (DateTime items in OnGoingAlarms)
            {
                bool timerAlreadyExists = false;
                items.Add(timedifference);
                foreach (string hfTimers in timerStrArray)
                {
                    DateTime tempD;// = Convert.ToDateTime(hfTimers);

                    if (DateTime.TryParse(hfTimers, ci, DateTimeStyles.None, out tempD) && tempD + fudgeFactor > items && tempD - fudgeFactor < items)
                    {
                        timerAlreadyExists = true;
                        break;
                    }

                }

                if (timerAlreadyExists == false)
                {
                    AddTimer(items, false);
                }
                #region
                // need to look at the various timers and either add them or not.

                //if (itemDateTime + timedifference + fudgeFactor > DateTime.Now || itemDateTime - timedifference - fudgeFactor < DateTime.Now)
                //{
                //    // do nothing, this is close enough
                //}
                //else
                //{

                //}
                //if (itemDateTime > DateTime.Now)
                //{
                //if (timerCount > 0)
                //    updateHF.Append("," + item);
                //else
                //    updateHF.Append(item);
                //timerCount++;
                //}
                #endregion
            }
            //hfPresentTimerList.Value = updateHF.ToString();
        }

        private void AddTimer(DateTime countDownTo, bool localClient)
        {
            if (hfPresentTimerList.Value.Length == 0)
            {
                hfPresentTimerList.Value = countDownTo.ToString("G", DateTimeFormatInfo.InvariantInfo);
                hfPresentTimerTitleList.Value = (localClient) ? tbTimerLabel.Text : "";
            }
            else
            {
                hfPresentTimerList.Value += "," + countDownTo.ToString("G", DateTimeFormatInfo.InvariantInfo);
                hfPresentTimerTitleList.Value += hfPresentTimerTitleList.Value = (localClient) ? "," + tbTimerLabel.Text : ",";
            }
        }

        private List<DateTime> ParseAlarms()
        {
            List<DateTime> returnList = new List<DateTime>();
            if (Status.ContainsKey("TotalTimers"))
            {
                int totalTimers;
                int.TryParse(Status["TotalTimers"], out totalTimers);
                for (int i = 0; i < totalTimers; i++)
                {
                    if (Status.ContainsKey("Timer" + i))
                    {
                        DateTime timer;
                        if (DateTime.TryParse(Status["Timer" + i], out timer))
                        {
                            returnList.Add(timer);
                        }
                    }
                }
            }
            return returnList;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewTimer_Click(object sender, EventArgs e)
        {
            DateTime countDownTo = DateTime.Now;
            double minutes;
            double.TryParse(tbNewTime.Text, out minutes);

            //btnAddkNewTimer(minutes);
            countDownTo = countDownTo.AddSeconds((minutes * 60));

            BrewControl.SetTimer(minutes.ToString());

            AddTimer(countDownTo, true);
            //if (hfPresentTimerList.Value.Length == 0)
            //{
            //    hfPresentTimerList.Value = countDownTo.ToString("G", DateTimeFormatInfo.InvariantInfo);
            //    hfPresentTimerTitleList.Value = tbTimerLabel.Text;
            //}
            //else
            //{
            //    hfPresentTimerList.Value += "," + countDownTo.ToString("G", DateTimeFormatInfo.InvariantInfo);
            //    hfPresentTimerTitleList.Value += "," + tbTimerLabel.Text;
            //}


            //int timersNotAllocated;
            //int.TryParse(Status["TimersNotAllocated"], out timersNotAllocated);
            //timersNotAllocated -= 1;
            //Status["TimersNotAllocated"] = timersNotAllocated.ToString();
            UpdateReadings();

        }
        public bool GetchkSoundAlarm()
        {
            return chkSoundAlarm.Checked;
        }
        //private void btnAddNewTimer(double minutes)
        //{
        //    throw new NotImplementedException();
        //}

        public void ResetAlarm()
        {
            string[] timerStrArray = hfPresentTimerList.Value.Split(',');
            StringBuilder updateHF = new StringBuilder();
            CultureInfo ci = new CultureInfo("en-US");

            int timerCount = 0;
            foreach (string item in timerStrArray)
            {
                DateTime itemDateTime;
                DateTime.TryParse(item, ci, DateTimeStyles.None, out itemDateTime);
                
                if (itemDateTime > DateTime.Now)
                {
                    if (timerCount > 0)
                        updateHF.Append("," + item);
                    else
                        updateHF.Append(item);
                    timerCount++;
                }
            }
            hfPresentTimerList.Value = updateHF.ToString();

        }
        /// <summary>
        /// used to remove all alarms except for ones that expire, those are stripped when the ResetAlarm() is called.
        /// </summary>
        public void StripAlarms()
        {
            string[] timerStrArray = hfPresentTimerList.Value.Split(',');
            StringBuilder updateHF = new StringBuilder();

            int timerCount = 0;
            foreach (string item in timerStrArray)
            {
                DateTime itemDateTime;
                if (DateTime.TryParse(item, out itemDateTime))
                {
                    if (itemDateTime <= DateTime.Now)
                    {
                        if (timerCount > 0)
                            updateHF.Append("," + item);
                        else
                            updateHF.Append(item);
                        timerCount++;
                    }
                }
            }
            hfPresentTimerList.Value = updateHF.ToString();

        }
    }
}