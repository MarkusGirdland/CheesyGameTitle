<%@ Page Title="Min" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheesyGameTitle._Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>
<LINK rel="stylesheet" type="text/css" href="Style.css" />

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Cheesy Game Title!</title>
</head>
<body id="body" runat="server" class="body"> 
        <form id="form1" runat="server" submitdisabledcontrols="True" visible="True">
            <asp:HyperLink ID="RulesLink" runat="server" NavigateUrl="~/Rules.aspx">Rules</asp:HyperLink>
            <asp:ImageButton CSSclass="mybtn" ID="StartButton" runat="server" OnClick="StartButton_Click" ImageUrl="~/Images/start.jpg" /> 

            <asp:ImageButton CSSClass="charbtn" ID="RatButton" runat="server" ImageUrl="~/Images/PlaceHolder.jpg" OnClick="RatButton_Click" />
            <asp:ImageButton CSSClass="charbtn" ID="MouseButton" runat="server" Enabled="false" ImageUrl="~/Images/KommerSnart.jpg" Visible="False" />

            <asp:ImageButton ID="NewTurnButton" runat="server" Visible="false" OnClick="NewTurn_Click" ImageUrl="~/Images/NewTurn.png" CssClass="mybtn" />
            <asp:ImageButton ID="CheeseButton" runat="server" Visible="false" OnClick="CheeseButton_Click" ImageUrl="~/Images/Attack.jpg" CssClass="mybtn" />

            <div class="cardDiv" runat="server">

                <asp:Label ID="CardHeader" runat="server"></asp:Label>
                <asp:Label ID="CardText" runat="server"></asp:Label>

                <asp:Image ID="cardImage" runat="server" ImageUrl="~/Images/kort.png" Visible="false"/>
            </div>
           
            <div class="charStats" runat="server">
                <asp:Label ID="statsBox" runat="server"></asp:Label>
            </div>

            <br />
            <br />

            <div class="LeftScreen" runat="server">
                <asp:Label ID="PlayerBox" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label ID="MonsterBox" runat="server"></asp:Label>
                <br />
                <br />

                <asp:Label ID="CombatBox" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label ID="CombatLog" runat="server"></asp:Label>
                <asp:Label ID="LabelRead" runat="server"></asp:Label>
                <br />
            </div>

            <asp:ImageButton ID="TryAgainButton" runat="server" Visible="false" OnClick="TryAgainButton_Click" ImageUrl="~/Images/tryAgain.jpg" CssClass="mybtn" />

            <script src="Scripts/JavaScript.js" type="text/javascript"></script>
        
            <asp:Image ID="ratCharacter" runat="server" ImageUrl="~/Images/råttaFramåt.png"/>

            <div id="bodyDiv" class="bodyDiv" runat="server">
            </div>
        </form>
    
</body>
</html>