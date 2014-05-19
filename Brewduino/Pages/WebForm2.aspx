<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Brewduino.Pages.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblStatus" runat="server" Text="Initial Load" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnPreOpen" runat="server" Text="PreOpen" OnClick="btnPreOpen_OnClick" />
                </td>
            </tr>
            <tr>
                <td>
                    Command:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCommand" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Which thermometer
                </td>
                <td>
                    <asp:DropDownList ID="ddlThermo" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnTest" runat="server" OnClick="btnTest_OnClick" Text="OpenPort" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblTest" runat="server" Text="Nothing loaded yet" />
    </div>
    </form>
</body>
</html>
