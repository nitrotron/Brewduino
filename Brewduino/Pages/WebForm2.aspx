<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Brewduino.Pages.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Hello There
    <asp:Label ID="lblTest" runat="server" Text="Nothing loaded yet" />
    <asp:Button ID="btnPreOpen" runat="server" Text="PreOpen" OnClick="btnPreOpen_OnClick" />
    <asp:Button ID="btnTest" runat="server" OnClick="btnTest_OnClick" Text="OpenPort"/>
    </div>
    </form>
</body>
</html>
