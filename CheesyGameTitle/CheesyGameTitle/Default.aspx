<%@ Page Title="Min" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheesyGameTitle._Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>
<LINK rel="stylesheet" type="text/css" href="Style.css" />

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Min</title>
</head>
<body id="body">
    <form id="form1" runat="server" submitdisabledcontrols="True" visible="True">

    <h1>Cheesy Game Title</h1>
        <asp:HyperLink ID="RulesLink" runat="server" NavigateUrl="~/Rules.aspx">Rules</asp:HyperLink>
        <asp:ImageButton CSSclass="mybtn" ID="StartButton" runat="server" OnClick="StartButton_Click" ImageUrl="~/Images/start.jpg" /> 

        <asp:ImageButton CSSClass="charbtn" ID="RatButton" runat="server" ImageUrl="~/Images/PlaceHolder.jpg" Visible="False" OnClick="RatButton_Click" />
        <asp:ImageButton CSSClass="charbtn" ID="MouseButton" runat="server" Enabled="false" ImageUrl="~/Images/KommerSnart.jpg" Visible="False" />

        <asp:ImageButton ID="NewTurnButton" runat="server" Visible="false" OnClick="NewTurn_Click" ImageUrl="~/Images/NewTurn.png" CssClass="mybtn" />

        <asp:Label ID="CardHeader" runat="server"></asp:Label>
        <asp:Label ID="CardText" runat="server"></asp:Label>

        <br />
        <br />

        <asp:Label ID="PlayerBox" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="MonsterBox" runat="server"></asp:Label>
        <br />
        <br />

        <asp:Label ID="CombatBox" runat="server"></asp:Label>

        <br />
        
        <script src="Scripts/JavaScript.js" type="text/javascript"></script>

    </form>
</body>
</html>