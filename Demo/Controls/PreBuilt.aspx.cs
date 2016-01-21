using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;

namespace Demos.Controls
{
    public partial class PreBuilt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GControl control = new GControl(GControl.preBuilt.LargeMapControl3D);
            GControl control2 = new GControl(GControl.preBuilt.MenuMapTypeControl, new GControlPosition(GControlPosition.position.Top_Right));

            GMap1.addControl(control);
            GMap1.addControl(control2);
            GMap1.addControl(new GControl(GControl.preBuilt.NavLabelControl, new GControlPosition(GControlPosition.position.Bottom_Left))); 
        }
    }
}