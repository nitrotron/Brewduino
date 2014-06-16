<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScratchPad.aspx.cs" Inherits="Brewduino.Pages.ScratchPad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Fonts/font-awesome-4.1.0/css/font-awesome.css" rel="stylesheet" />
    <link href="~/Fonts/fontello-374a6348/css/misc.css" rel="stylesheet" type="text/css" />
    </head>
<body style="background-color: White">
     <form id="form1" runat="server">
        <div class="switch demo4">
            <input type="checkbox">
            <label>
                <%--<i class="icon-off"></i>--%>
                <%--<i  class="fa fa-power-off" style="line-height: 2.2;"></i>--%>
    <%--            <span class="fa-stack ">
                <i class="fa fa-exclamation fa-stack-1x" style="line-height: 2.2;"></i>
                <i class="fa fa-circle-thin fa-stack-1x" style="line-height: 2.2;"></i>
                </span>--%>
                <i class="icon-attention-alt"></i>
            </label>
           
        </div>
        <div class="switch demo4">
        <asp:CheckBox ID="chkScratchPad" runat="server" AutoPostBack="true" Text="<i class='icon-attention-alt'></i>" OnCheckedChanged="chkScratchPad_CheckedChanged" />
<%--            <label>
                <i class="icon-attention-alt"></i>
            </label>
            </asp:CheckBox> --%>
           
        </div>
    </form>
</body>
</html>
