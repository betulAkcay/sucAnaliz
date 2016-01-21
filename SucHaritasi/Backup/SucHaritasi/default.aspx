<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SucHaritasi._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <cc1:GMap ID="GMap1" runat="server" Width="800px" Height="600px" enableGoogleBar="True"
                        enableRotation="True" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Chart ID="chartSucOranlari" runat="server">
                        <Series>
                            <asp:Series Name="Series1" XValueMember="Suc" YValueMembers="Sayi">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Titles>
                            <asp:Title BackColor="White" Font="Microsoft Sans Serif, 9.75pt, style=Bold" Name="Title1"
                                Text="SUÇ ORANLARI">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>
                </td>
                <td>
                    <asp:Chart ID="chartYillaraGoreOranlar" runat="server">
                        <Series>
                            <asp:Series Name="Series2" XValueMember="Yil" YValueMembers="Sayi">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea2">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Titles>
                            <asp:Title BackColor="White" Font="Microsoft Sans Serif, 9.75pt, style=Bold" Name="Title2"
                                Text="YILLARA GÖRE SUÇ MİKTARI">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbSucTipineGore" Text="Suç Tipine Göre Arama" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="cbSucListesi" runat="server" Height="22px" Width="125px">
                        <asp:ListItem Text="Seçiniz" Value="Seçiviz"></asp:ListItem>
                        <asp:ListItem Text="Dolandırıcılık" Value="Dolandırıcılık"></asp:ListItem>
                        <asp:ListItem Text="Tehdit" Value="Tehdit"></asp:ListItem>
                        <asp:ListItem Text="Uyuşturucu" Value="Uyuşturucu"></asp:ListItem>
                        <asp:ListItem Text="Hırsızlık" Value="Hırsızlık"></asp:ListItem>
                        <asp:ListItem Text="Soygun" Value="Soygun"></asp:ListItem>
                        <asp:ListItem Text="Tecavüz" Value="Tecavüz"></asp:ListItem>
                        <asp:ListItem Text="Şiddet" Value="Şiddet"></asp:ListItem>
                        <asp:ListItem Text="Ateşli silah" Value="Ateşli silah"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbTariheGore" Text="Tarihe Göre Arama" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtTarih" runat="server"></asp:TextBox>
                </td>
                <td>
                    (gg.aa.yyyy) ör:11.10.2001
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbAdreseGore" Text="Adrese Göre Arama" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtAdres" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbCinsiyeteGore" Text="Cinsiyet" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="cbCinsiyet" runat="server" Height="22px" Width="125px">
                        <asp:ListItem Text="Seçiniz" Value="Seçiniz"></asp:ListItem>
                        <asp:ListItem Text="Bay" Value="Erkek"></asp:ListItem>
                        <asp:ListItem Text="Bayan" Value="Kadın"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbYasaGore" Text="Yaş" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtYas" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbBolgeyeGore" Text="Bölgeye Göre Grafik" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtGrafik" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbYillaraGore" Text="Yıllara Göre Grafik" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbMekanaGore" Text="Mekana Göre Arama" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtMekan" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnVerileriGetir" runat="server" OnClick="btnVerileriGetir_Click"
                        Text="Verileri Getir" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
