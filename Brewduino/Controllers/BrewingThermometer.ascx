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
        <asp:Panel ID="pnlRimsButton" runat="server" Visible="false">
            <div id="btnShowRimsControls" class="Clickable">
                <div id="pnlRimsControls" style="display: none;" class="RimsSettingContainterXXXXX">
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
                                <asp:Button ID="btnUpdateRims" runat="server" Text="Set" OnClick="btnUpdateRims_Click"
                                    CssClass="btnUpdateRims" />
                                <asp:Button ID="btnUpdateRimsCancel" runat="server" Text="Cancel" OnClick="btnUpdateRimsCancel_Click"
                                    CssClass="btnUpdateRims" />
                            </td>
                        </tr>
                    </table>
                </div>
                <i class='icon-beer'></i>RIMS Settings
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlSetAlarm" CssClass="PanelOverlay" runat="server" Visible="false">
            <asp:Label ID="lblAlarmTitle" runat="server" />
            <br />
            <asp:TextBox ID="tbAlarm" runat="server" Width="33%" />
            <asp:Button ID="btnUpdateAlarms" runat="server" OnClick="btnUpdateAlarms_OnClick"
                Text="Update" />
            <asp:Button ID="btnCancelAlarms" runat="server" OnClick="btnCancelAlarms_OnClick"
                Text="Cancel" />
            <asp:HiddenField ID="hfWhichAlarm" runat="server" />
        </asp:Panel>
    </div>
</div>
<script type="text/javascript">
    function BindEvents3() {
        $("#btnShowRimsControls").click(function () {
            $("#pnlRimsControls").slideDown('slow');
        });
    };
    Sys.Application.add_load(BindEvents3);
  
</script>
