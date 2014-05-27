<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RimsPanel.aspx.cs" Inherits="Brewduino.Pages.RimsPanel" %>
<%@ Register Src="~/Controllers/BrewingThermometer.ascx" TagPrefix="uc1" TagName="BrewThermometer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMainAlarm" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnResetAlarm" runat="server" OnClick="btnResetAlarm_OnClick" Text="Reset Alarms"/>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:BrewThermometer ID="btRims" runat="server" />
            </td>
            <td>
                <uc1:BrewThermometer ID="btMash" runat="server" />
            </td>
            <td>
                <uc1:BrewThermometer ID="btKettle" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
