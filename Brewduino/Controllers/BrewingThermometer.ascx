<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrewingThermometer.ascx.cs"
    Inherits="Brewduino.Controllers.BrewingThermometer" %>
<div id="BrewingThermometerMain">
    <asp:Label ID="lblTitle" runat="server" CssClass="BrewingThermometer_Title" Text="Title" />
    <br />
    <div id="BrewingThermometer_Display">
        <asp:LinkButton ID="lblCurrentTemp" runat="server" CssClass="TemperatureDigital"
            Text="180" OnClick="btnCurrentTemp_OnClick" />
        <asp:LinkButton ID="btnTempHighAlarm" runat="server" CssClass="TemperatureDigitalSmallTop"
            Text="200" OnClick="btnTempHighAlarm_OnClick" />
        <asp:LinkButton ID="btnTempLowAlarm" runat="server" CssClass="TemperatureDigitalSmallBottom"
            Text="-10" OnClick="btnTempLowAlarm_OnClick" />
            <br />
        <asp:Panel ID="pnlRimsButton" runat="server" Visible=false>
            <div id="btnShowRimsControls" class="Clickable">
                <i class='icon-beer'></i>Rims Settings
            </div>
        </asp:Panel>
        <div id="pnlRimsControls" style="display: none;" class="RimsSettingContainter">
            <table>
                <tr>
                    <td class="RimsSettingLabel">
                        Set Point:
                    </td>
                    <td class="RimsSettingTB">
                        <asp:TextBox ID="tbSetPoint" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="RimsSettingLabel">
                        WindowSize:
                    </td>
                    <td class="RimsSettingTB">
                        <asp:TextBox ID="tbWindowSize" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="RimsSettingLabel">
                        Kp:
                    </td>
                    <td class="RimsSettingTB">
                        <asp:TextBox ID="tbKp" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="RimsSettingLabel">
                        Ki:
                    </td>
                    <td class="RimsSettingTB">
                        <asp:TextBox ID="tbKi" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="RimsSettingLabel">
                        Kd:
                    </td>
                    <td class="RimsSettingTB">
                        <asp:TextBox ID="tbKd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="RimsSettingTB">
                        <asp:Button ID="btnUpdateRims" runat="server" Text="Set" OnClick="btnUpdateRims_Click" CssClass="btnUpdateRims" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="pnlSetAlarm" CssClass="PanelOverlay" runat="server" Visible="false">
            <asp:Label ID="lblAlarmTitle" runat="server" />
            <br />
            <asp:TextBox ID="tbAlarm" runat="server" />
            <asp:Button ID="btnUpdateAlarms" runat="server" OnClick="btnUpdateAlarms_OnClick"
                Text="Update" />
            <asp:HiddenField ID="hfWhichAlarm" runat="server" />
        </asp:Panel>
    </div>
</div>
<script type="text/javascript">
    function BindEvents3() {
        $("#btnShowRimsControls").click(function () {
            debugger;
            $("#pnlRimsControls").fadeIn('slow');
        });
    };
    Sys.Application.add_load(BindEvents3);
  
</script>
