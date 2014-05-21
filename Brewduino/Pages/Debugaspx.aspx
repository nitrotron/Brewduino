<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Debugaspx.aspx.cs" Inherits="Brewduino.Pages.Debugaspx" %>

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
                <td>
                    Status:
                </td>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="Initial load" />
                </td>
            </tr>
            <tr>
                <td>
                    Info:
                </td>
                <td>
                    <asp:Label ID="lblInfo" runat="server" Text="No Info:" />
                </td>
            </tr>
            <tr>
                <td>
                    Action
                </td>
                <td>
                    <asp:DropDownList ID="ddlAction" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_OnClick" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
