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
        protected ArduinoSerial mySerial = new ArduinoSerial();
        protected BrewController BrewControl;
        protected void Page_Load(object sender, EventArgs e)
        {
            BrewControl = new BrewController(mySerial);
            mySerial.OpenPort();

            if (!IsPostBack)
            {
                PopulateTemperatures();
            }
            
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            mySerial.ClosePort();
        }

        private void PopulateTemperatures()
        {
            lblRIMSTemp.Text = BrewControl.GetTemps(BrewController.ThermometersName.RIMS).ToString();
            lblMashTemp.Text = BrewControl.GetTemps(BrewController.ThermometersName.MashTun).ToString();
        }

        protected void btnSetHighAlarm_click(object sender, EventArgs e)
        {
            BrewControl.SetHighTempAlarm(BrewController.ThermometersName.MashTun, Convert.ToInt16(tbMashHighAlarm.Text));
        }
    }
}
