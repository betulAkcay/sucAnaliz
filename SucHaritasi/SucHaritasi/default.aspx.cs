using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Subgurim.Controles;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.Data;


namespace SucHaritasi
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string yolKarakol = Server.MapPath("~\\veritabani\\karakol.txt");
                string[] satirlar1 = File.ReadAllLines(yolKarakol, System.Text.UTF8Encoding.UTF8);

                foreach (var satir in satirlar1)
                {
                    string[] dataKolon1 = satir.Split(';');
                    KarakolYerlestir(dataKolon1);
                }
            }
        }

        protected void btnVerileriGetir_Click(object sender, EventArgs e)
        {
            try
            {
                CultureInfo culture = new CultureInfo("tr-TR");
                string yol = Server.MapPath("~\\veritabani\\sucdefteri.txt");
                string[] satirlar = File.ReadAllLines(yol, System.Text.UTF8Encoding.UTF8);

                int soygun = 0, hirsizlik = 0, tehdit = 0, tecavuz = 0, dolandiricilik = 0, uyusturucu = 0, atesliSilah = 0, siddet = 0, intihar = 0;
                int sayac1 = 0, sayac2 = 0;

                foreach (var satir in satirlar)
                {

                    string[] dataKolon = satir.Split(';');


                    if (cbSucTipineGore.Checked)
                    {
                        if (cbSucListesi.SelectedItem != null && cbSucListesi.SelectedItem.Value != "Seçiniz")
                        {
                            if (dataKolon[0] != cbSucListesi.SelectedItem.ToString())
                                continue;
                        }
                    }

                    if (cbTariheGore.Checked)
                    {
                        if (DateTime.ParseExact(txtTarih.Text, "dd.MM.yyyy", culture) !=
                            DateTime.ParseExact(dataKolon[1], "yyyy.MMMM.dd", culture))
                            continue;

                    }

                    if (cbAdreseGore.Checked)
                    {
                        if (!txtAdres.Text.Contains(dataKolon[2]))
                            continue;
                    }

                    if (cbCinsiyeteGore.Checked)
                    {
                        if (cbCinsiyet.SelectedItem != null && cbCinsiyet.SelectedItem.Value != "Seçiniz")
                        {
                            if (dataKolon[3] != cbCinsiyet.SelectedItem.ToString())
                                continue;
                        }
                    }
                    if (cbYasaGore.Checked)
                    {
                        if (!txtYas.Text.Contains(dataKolon[4]))
                            continue;
                    }

                    Color sucRengi = Color.Red;
                    if (cbBolgeyeGore.Checked)
                    {
                        string yazi = txtGrafik.Text;
                        if (dataKolon[2].IndexOf(yazi) != -1)
                            if (dataKolon[0] == "Dolandırıcılık")
                            {
                                sucRengi = Color.Orange;
                                dolandiricilik++;
                            }
                            else if (dataKolon[0] == "Tehdit")
                            {
                                sucRengi = Color.Yellow;
                                tehdit++;
                            }
                            else if (dataKolon[0] == "Uyuşturucu")
                            {
                                sucRengi = Color.White;
                                uyusturucu++;
                            }
                            else if (dataKolon[0] == "Ateşli silah")
                            {
                                sucRengi = Color.Red;
                                atesliSilah++;
                            }
                            else if (dataKolon[0] == "Soygun")
                            {
                                sucRengi = Color.Black;
                                soygun++;
                            }
                            else if (dataKolon[0] == "Tecavüz")
                            {
                                sucRengi = Color.Green;
                                tecavuz++;
                            }
                            else if (dataKolon[0] == "Şiddet")
                            {
                                sucRengi = Color.Purple;
                                siddet++;
                            }
                            else if (dataKolon[0] == "Hırsızlık")
                            {
                                sucRengi = Color.Blue;
                                hirsizlik++;
                            }
                            else if (dataKolon[0] == "İntihar")
                            {
                                sucRengi = Color.Pink;
                                intihar++;
                            }


                        DataTable table = new DataTable("Suclar");
                        table.Columns.Add("Suc");
                        table.Columns.Add("Sayi", typeof(int));

                        table.Rows.Add(new object[] { "Ateşli silah", atesliSilah });
                        table.Rows.Add(new object[] { "Şiddet", siddet });
                        table.Rows.Add(new object[] { "Dolandiricilik", dolandiricilik });
                        table.Rows.Add(new object[] { "Hırsızlık", hirsizlik });
                        table.Rows.Add(new object[] { "Uyuşturucu", uyusturucu });
                        table.Rows.Add(new object[] { "İntihar", intihar });
                        table.Rows.Add(new object[] { "Soygun", soygun });
                        table.Rows.Add(new object[] { "Tecavüz", tecavuz });
                        table.Rows.Add(new object[] { "Tehdit", tehdit });


                        chartSucOranlari.DataSource = table;
                        chartSucOranlari.DataBind();
                    }
                    if (cbYillaraGore.Checked)
                    {

                        string[] tarih = dataKolon[1].Split('.');

                        if (tarih[0] == "2011")
                        {
                            sayac1++;
                        }
                        else if (tarih[0] == "2012")
                        {
                            sayac2++;
                        }

                        DataTable table = new DataTable("Yillar");
                        table.Columns.Add("Yil");
                        table.Columns.Add("Sayi", typeof(int));

                        table.Rows.Add(new object[] { "2011", sayac1 });
                        table.Rows.Add(new object[] { "2012", sayac2 });


                        chartYillaraGoreOranlar.DataSource = table;
                        chartYillaraGoreOranlar.DataBind();
                    }
                    if (cbMekanaGore.Checked)
                    {

                        GeoCode geo = new GeoCode();
                        geo = GMap1.getGeoCodeRequest(txtMekan.Text);

                        GLatLng gLatLng = new Subgurim.Controles.GLatLng(geo.Placemark.coordinates.lat, geo.Placemark.coordinates.lng);
                        double x1 = gLatLng.lat;
                        double y1 = gLatLng.lng;

                        geo = GMap1.getGeoCodeRequest(dataKolon[2]);

                        GLatLng gLatLng1 = new Subgurim.Controles.GLatLng(geo.Placemark.coordinates.lat, geo.Placemark.coordinates.lng);

                        double x2 = gLatLng1.lat;
                        double y2 = gLatLng1.lng;


                        double sonuc = KoordinatBul(x1, y1, x2, y2);
                        if (sonuc > 10000)
                        {
                            continue;
                        }

                    }


                    SucHarYerlestir(dataKolon, sucRengi);

                }

            }
            catch (Exception x)
            {

                Response.Write("<script language=\"Javascript\">");
                Response.Write("alert(\"Hata Oluştu: " + x.ToString() + "\");");
                Response.Write("</script>");
            }

        }

        public void SucHarYerlestir(string[] dataKolon, Color sucRengi)
        {
            string sMapKey = ConfigurationManager.AppSettings["betulsucharitasiuygulamasi"].ToString();

            GeoCode geo = new GeoCode();
            geo = GMap1.getGeoCodeRequest(dataKolon[2]);

            GLatLng gLatLng = new Subgurim.Controles.GLatLng(geo.Placemark.coordinates.lat, geo.Placemark.coordinates.lng);
            GMap1.setCenter(gLatLng, 8, Subgurim.Controles.GMapType.GTypes.Normal);
            if (dataKolon[0] == "Dolandırıcılık")
            {
                sucRengi = Color.Orange;
            }
            else if (dataKolon[0] == "Tehdit")
            {
                sucRengi = Color.Yellow;
            }
            else if (dataKolon[0] == "Uyuşturucu")
            {
                sucRengi = Color.White;
            }
            else if (dataKolon[0] == "Ateşli silah")
            {
                sucRengi = Color.Red;
            }
            else if (dataKolon[0] == "Soygun")
            {
                sucRengi = Color.Black;
            }
            else if (dataKolon[0] == "Tecavüz")
            {
                sucRengi = Color.Green;
            }
            else if (dataKolon[0] == "Şiddet")
            {
                sucRengi = Color.Purple;
            }
            else if (dataKolon[0] == "Hırsızlık")
            {
                sucRengi = Color.Blue;
            }
            else if (dataKolon[0] == "İntihar")
            {
                sucRengi = Color.Pink;
            }


            GIcon icon = new GIcon();
            icon.markerIconOptions = new MarkerIconOptions(20, 20, sucRengi);

            GMarker oMarker = new GMarker(gLatLng, icon);

            GInfoWindow window = new GInfoWindow(oMarker, "<div><span style=\"background-color:White\">suç tipi: " + dataKolon[0] + "</span></div><div>Tarih: " + dataKolon[1] +
            "</span></div><div>Adres: " + dataKolon[2] + "</div><div>Cinsiyet:"
            + dataKolon[3] + "</span></div><div>Yaş: " + dataKolon[4] + "</div>", false, GListener.Event.mouseover);


            GMap1.addInfoWindow(window);
            GMap1.addGMarker(oMarker);


        }
        private void KarakolYerlestir(string[] dataKolon1)
        {
            string sMapKey = ConfigurationManager.AppSettings["betulsucharitasiuygulamasi"].ToString();

            GeoCode geo = new GeoCode();
            geo = GMap1.getGeoCodeRequest(dataKolon1[1]);

            GLatLng gLatLng = new Subgurim.Controles.GLatLng(geo.Placemark.coordinates.lat, geo.Placemark.coordinates.lng);
            GMap1.setCenter(gLatLng, 8, Subgurim.Controles.GMapType.GTypes.Normal);


            GIcon icon = new GIcon();
            icon.markerIconOptions = new MarkerIconOptions(25, 25, Color.Gray);



            GMarker oMarker = new GMarker(gLatLng, icon);


            GInfoWindow window = new GInfoWindow(oMarker, "<div><span style=\"background-color:White\">Karakol adı: " + dataKolon1[0] + "</span></div><div>Adres: " + dataKolon1[1] + "</div>", false, GListener.Event.mouseover);

            GMap1.addInfoWindow(window);
            GMap1.addGMarker(oMarker);
        }
        public double KoordinatBul(double x1, double y1, double x2, double y2)
        {
            double R = 6371;

            double deltaX = DegToRad(x2 - x1);
            double deltaY = DegToRad(y2 - y1);
            double a = Math.Sin(deltaX / 2) * Math.Sin(deltaX / 2) +
                    Math.Cos(DegToRad(x1)) * Math.Cos(DegToRad(x2)) *
                                Math.Sin(deltaY / 2) * Math.Sin(deltaY / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;
            return d;

        }
        private static double DegToRad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
    }
}
        