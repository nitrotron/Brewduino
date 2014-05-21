using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;

namespace Brewduino.Pages
{
    public partial class Debugaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            PopulateDdlAction();
        }

        private void PopulateDdlAction()
        {
          
        }
        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
        }
    }
}