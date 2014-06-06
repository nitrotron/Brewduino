using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;





namespace Brewduino
{
    public partial class _Default : System.Web.UI.Page
    {
       // protected ArduinoSerial mySerial = new ArduinoSerial();
        protected BrewController BrewControl;
        protected void Page_Load(object sender, EventArgs e)
        {
            //BrewControl = new BrewController(mySerial);
            //mySerial.OpenPort();

            if (!IsPostBack)
            {
                PopulateTemperatures();
            }
            
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            //mySerial.ClosePort();
        }

        private void PopulateTemperatures()
        {
            lblRIMSTemp.Text = "RIMS Temp=" + BrewControl.GetTemps(BrewController.ThermometersName.RIMS).ToString();
            lblMashTemp.Text = "Mash Temp=" + BrewControl.GetTemps(BrewController.ThermometersName.MashTun).ToString();
            lblKettleTemp.Text = "Kettle Temp=" + BrewControl.GetTemps(BrewController.ThermometersName.Kettle).ToString();
        }

        protected void btnSetHighAlarm_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            BrewController.ThermometersName thermo;
            float value = 120;

            if (btn.ID == "btnSetHighAlarmMash")
            {
                thermo = BrewController.ThermometersName.MashTun;
                float.TryParse(tbMashHighAlarm.Text, out value);

            }
            else if (btn.ID == "btnSetHighAlarmRIMS")
            {
                thermo = BrewController.ThermometersName.RIMS;
                float.TryParse(tbRIMSHighAlarm.Text, out value);
            }
            else
            {
                thermo = BrewController.ThermometersName.Kettle;
                float.TryParse(tbKettleHighAlarm.Text, out value);
            }
            BrewControl.SetHighTempAlarm(thermo, value);
        }
    }
}
