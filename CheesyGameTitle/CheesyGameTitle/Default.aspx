<%@ Page Title="Cheesy Game Title!" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheesyGameTitle._Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>
<LINK rel="stylesheet" type="text/css" href="Style.css" />

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Cheesy Game Title!</title>
</head>
<body id="body" runat="server" class="body"> 
        <form id="form1" runat="server" submitdisabledcontrols="True" visible="True">
            <asp:HyperLink ID="RulesLink" runat="server" NavigateUrl="~/Rules.aspx">Pssst...läs reglerna här!</asp:HyperLink>
            <asp:ImageButton CSSclass="startButton" ID="StartButton" runat="server" OnClick="StartButton_Click" ImageUrl="~/Images/startButton.png" /> 

            <asp:ImageButton CSSClass="charbtn" ID="RatButton" runat="server" ImageUrl="~/Images/martinMus.png" OnClick="RatButton_Click" />
            <asp:ImageButton CSSClass="charbtn" ID="MouseButton" runat="server" Enabled="false" ImageUrl="~/Images/kommerSnart.png" Visible="False" />

            <asp:ImageButton ID="NewTurnButton" runat="server" Visible="false" OnClick="NewTurn_Click" ImageUrl="~/Images/nyttDrag.png" CssClass="mybtn" />
            <asp:ImageButton ID="CheeseButton" runat="server" Visible="false" OnClick="CheeseButton_Click" ImageUrl="~/Images/ostKnapp.png" CssClass="mybtn" />

            <div class="cardDiv" runat="server">

                <asp:Label CssClass="CardHeaderClass" ID="CardHeader" runat="server"></asp:Label>
                <asp:Label ID="CardText" runat="server"></asp:Label>

                <asp:Image ID="cardImage" runat="server" ImageUrl="~/Images/kort.png" Visible="false"/>
            </div>
           
            <div class="charStats" runat="server">
                <asp:Label ID="statsBox" CssClass="boxStyle" runat="server"></asp:Label>
            </div>

            <br />
            <br />

            <div class="LeftScreen" runat="server">
                <asp:Label ID="PlayerBox" CssClass="logStyle" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label ID="MonsterBox" CssClass="logStyle" runat="server"></asp:Label>
                <br />
                <br />

                <asp:Label ID="CombatBox" CssClass="logStyle" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label ID="CombatLog" CssClass="logStyle" runat="server"></asp:Label>
                <br />
                <asp:Label ID="TooSmallMessage" CssClass="tooSmall" runat="server" Text="Ditt fönster är för litet för att kunna spela spelet så det ser
                    bra ut. Förstora fönstret eller använd en dator med större skärm."></asp:Label>
            </div>

            <asp:ImageButton ID="TryAgainButton" runat="server" Visible="false" OnClick="TryAgainButton_Click" ImageUrl="~/Images/gameOver.png" CssClass="gameOver" />

            <script src="Scripts/JavaScript.js" type="text/javascript"></script>
        
            <asp:Image ID="ratCharacter" CssClass="ratCharacter" runat="server" ImageUrl="~/Images/råttaFramåt.png"/>

            <div id="bodyDiv" class="bodyDiv" runat="server">
            </div>
        </form>
    
</body>
</html>