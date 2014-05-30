<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Brewduino.Pages.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../Styles/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet">
	<script src="../Scripts/jquery-1.10.2.js"></script>
	<script src="../Scripts/jquery-ui-1.10.4.custom.js"></script>
	<script>
	    $(function () {


	        $("#slider").slider({
	            range: true,
	            values: [17, 67]
	        });


	    });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainTop" runat="server">
<h2 class="demoHeaders">Slider</h2>
<div id="slider"></div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
