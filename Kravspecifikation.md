#Kravspecifikation
####Av: mg222pi

##Cheesy Game Title

###Krav

Kraven ordnade i nummerordning.

####Aktörer
1, Primära aktörer

**Spelare**; Vill komma in på sidan och spela spelet utan problem. Använder spelet mest av alla.

**Support**; Vill enkelt kunna komma åt ett forum för att hjälpa folk med eventuella problem man kan ha med spelet.

2, Stödjande aktörer

**Framtida utvecklare**; Vill ha en bra strukturerad hemsida som man enkelt kan bygga på med mer innehåll.

**Administratör**; Vill kunna ha verktyg för att kunna överse sitt område av appen, exempelvis forumet där man kan ställa frågor.

3, Offstage aktörer

**Apples Appstore**; Vissa krav ställs på appen för att den ska få säljas i deras digitala affär.

**Facebook**; Eventuell senarelagd integration med Facebook för att enkelt kunna dela sina framsteg ställer krav på uppbyggnaden av hemsidan.

###Funktionella Krav

F1 Gå in på hemsidan

Spelare måste gå in på hemsidan och börja en spelsession.

Användningsfall
1 Spelare

AF1.1 Spelsesssion

2 Support*

AF2.1 Svara på forum*

3 Administratör*

AF3.1 Hantera forum*

*Eventuellt inplanerat efter avslutat projekt, testfall för AF1.1 endast nedskrivet.

### Testfall, AF1.1

En spelare vill se spela spelet.

####Huvudscenario

- Starar när en spelaren vill starta en spelsession. (1a)

- Systemet ber spelaren väljer i menyn att starta spelet.

- Systemet presenterar en eller flera karaktärer att välja mellan. (1b)

- Spelaren väljer karaktär och börjar spela. (1b)


####Alternativa scenarios

1a. Hemsidan ligger nere

Systemet presenterar felmeddelande, troligen 404.
Gå till steg 1 i huvudscenario.


1b. Hemsidan har eventuella problem med spelet

Systemet presenterar meddelande om att systemtekniska fel uppstått angående hemsidans data.
Systemet presenterar ett till meddelande om att uppdatera sidan och börja om igen.
Gå till steg 1 i huvudscenario.


##Kvalitetskrav
###Användbarhet

Kv1 Grafisk Utformning
Cheesy Game Title skall grafiskt utformas till att ha ett roligt, färgglatt samt enhetligt utseende.

###Förståelse

Kv2 Enkla texter 
Cheesy Game Title skall på ett enkelt sätt förmedla vad de olika korten gör och även ha en meny där man kan
välja att läsa reglerna.

###Stödbarhet

Kv3 Webbläsare
Cheesy Game Title skall kunna köras på en rimlig andel webbläsare och dess olika versioner.
