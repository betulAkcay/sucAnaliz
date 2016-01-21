using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;

namespace Demos.Controls
{
    public partial class GLayers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GLayer layerPanoramio = new GLayer(GLayerID.All_photos_from_panoramio_com);
            GMap1.addGLayer(layerPanoramio);

            GLayer layerWikipedia = new GLayer(GLayerID.Geotagged_Wikipedia_articles_Spanish);
            GMap1.Add(layerWikipedia);
        }
    }
}