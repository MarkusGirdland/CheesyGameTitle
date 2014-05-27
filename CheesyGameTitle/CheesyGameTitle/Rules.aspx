<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="CheesyGameTitle.Rules" %>

<!DOCTYPE html>
<LINK rel="stylesheet" type="text/css" href="RuleStyle.css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cheesy Game Title - Regler</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Cheesy Game Title!</h1>
    <h3>Grunderna</h3>
    <p>Cheesy Game Title går ut på att du spelar en karaktär som ska ta sig igenom köket och nå ostrutan. <br /> Väl på ostrutan måste du göra en bedömning
        om hur mycket ost du vill riskera att ta med dig utan att <br />väcka katten som ligger och sover vid osten. Ta med dig osten tillbaka och väl där
        får du till slut poängen!<br /> Ganska simpelt, eller hur?
    </p>

    <h3>
        Korten
    </h3>
        <p>Så vad gör spelet mindre simpelt? Varje drag du gör (förutom när du går till ostrutan eller sista rutan <br /> när spelet är slut) så drar du ett kort.
            Dessa kort kan både hjälpa dig eller hindra dig från att nå <br />ostrutan, eller så kan de helt enkelt inte påverka dig på något sätt alls.
        </p>

    <h3>
        Ostrutan
    </h3>
        <p>
            Väl på ostrutan så ska du samla allt mod och väga risk mot belöning och försöka ta med dig så mycket<br /> ost som möjligt utan att väcka katten. Varje
            gång du tar ost så går lite tid och kattens powernap går<br /> närmare och närmare sitt slut och ökar därmed risken för att han vaknar och dödar dig snabbare
            än du <br />hinner säga "pip"! <br />Hur modig är du? Kan du slå ditt personliga rekord? 
        </p>  
        
    <asp:HyperLink ID="RulesLink" runat="server" NavigateUrl="~/Default.aspx">Börja spela!</asp:HyperLink>  

    </div>
    </form>
</body>
</html>
