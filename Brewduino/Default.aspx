<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Brewduino._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>

    <asp:Label ID="lblRIMSTemp" Text="-999" runat="server"/>
    <asp:Label ID="lblMashTemp" Text="-999" runat="server" />
    <asp:Label ID="lblKettleTemp" Text="-999" runat="server" />
    
    <asp:TextBox ID="tbMashHighAlarm" runat="server" /> click to set Mash High Temp
    <asp:Button ID="btnSetHighAlarmMash" runat="server" OnClick="btnSetHighAlarm_click" />
    <asp:TextBox ID="tbRIMSHighAlarm" runat="server" /> click to set RIMS High Temp
    <asp:Button ID="btnSetHighAlarmRIMS" runat="server" OnClick="btnSetHighAlarm_click" />
    <asp:TextBox ID="tbKettleHighAlarm" runat="server" /> click to set Kettle High Temp
    <asp:Button ID="btnSetHighAlarmKettle" runat="server" OnClick="btnSetHighAlarm_click" />
</asp:Content>
