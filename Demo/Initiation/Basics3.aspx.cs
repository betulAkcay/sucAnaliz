using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;

namespace Demos.Initiation
{
    public partial class Basics3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GMap1.setCenter(new GLatLng(40, 1));
            GMap2.setCenter(new GLatLng(39, 2));

            GMap1.addControl(new GControl(GControl.extraBuilt.TextualCoordinatesControl));
            GMap1.addControl(new GControl(GControl.extraBuilt.MarkCenter));
            GMap2.addControl(new GControl(GControl.extraBuilt.TextualCoordinatesControl));
            GMap2.addControl(new GControl(GControl.extraBuilt.MarkCenter));

            TabPanel1.OnClientClick = GMap1.getChangeHiddenStateFunction();
            TabPanel3.OnClientClick = GMap2.getChangeHiddenStateFunction();

            TabContainer1.ActiveTabIndex = 0;
        }
    }
}