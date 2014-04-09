# Spelregler

### Innehållsförteckning

Introduktion

Karaktärer

Kort

- Tomt

- Monsterkort

- Föremålskort

- Fällkort

Ostrutan

There and back again...

## Introduktion

Spelets mål är att, inne i huset, nå osten. Spelet kommer ha 7* steg där det sjunde steget är själva ostrutan. Man rör sig ett steg varje rond och för varje steg så drar man ett kort som kommer förklaras under sin egna rubrik längre ner. Kortfattat kan man säga att korten innehåller olika faror eller föremål som man ska klara av för att ta sig till osten. Väl vid osten ska man varje drag sno på sig så mycket ost som möjligt utan att väcka huskatten, för varje drag du snor ost och inte väcker katten så ökar risken för att katten ska vakna. Man måste alltså balansera risken mot belöningen. När man är nöjd med hur mycket ost man har ska man gå tillbaka till sitt hål i väggen och man får därefter poäng beroende på hur mycket ost du lyckades få. 

*Kan ändras för balansering

## Karaktärer

Till början kommer jag implementera en karaktär, en råtta, som man kan spela. Får jag tid över kommer man även kunna välja en mus. Skillnaden mellan de två tänkte jag skulle vara att råttan är starkare och tål mer men musen är mer smidig och kan enklare undvika vissa faror istället.

En karaktär kommer bestå av hälsa(health), styrka(strength), smidighet(agility) samt intelligens(intelligence). Dessa attribut kommer vara hjälpsamma beroende på vad det är för fara man möter. 

## Kort

Kort kommer delas in i olika kategorier.

### Tomt

Varje gång man drar ett kort finns en chans att rutan man står på är tom, detta betyder att ingenting händer denna runda förutom att karaktären flyttade sig ett steg framåt.

### Monsterkort

Stöter man på ett "monster" på en ruta kommer man strida mot monstret. Varje monster har attributen "Hälsa(health)" samt en primär attribut, exempelvis "Styrka(strength)". Beroende på vad den primära attributet för monstret är så kommer man strida med det attributet som grund. Spelaren och monstret slår en tärning (T6) och lägger på det antalet på sitt eget attribut.

Exempel:
Monstret har 3 styrka och det är dess primära attribut, man slåss via styrka.
Råttan har 6 styrka.

Monstret slår 5 på tärningen, (3 + 5 = 8), monstret får en sammanlagd styrka på 8.
Råttan slår 3 på tärningen, (6 + 3 = 9), råttan får en sammanlagd styrka på 9.

Råttan tar bort en hälsa från monstret.

Detta pågår till råttan har tagit bort all hälsa från monstret eller tills dess att monstret gjort 3 skada på råttan, efter det nöjer sig monstret och känner att han har gjort sitt och går tillbaka.

Monsterkort som planeras att hinnas med är följande:
OSB Samtliga nummer här kan ändras pga balans, detta är endast preliminära nummer för att få en start.

#### Rivaliserande Råtta

Primär attribut: Styrka, 4 poäng.

Hälsa: 3

#### Husets Marsvin
Primär attribut: Styrka, 5 poäng.

Hälsa: 4

#### Rivaliserande Mus
Primär attribut: Smidighet, 4 poäng.

Hälsa: 2

#### Irriterande Fluga
Primär attribut: Smidighet, 6 poäng.

Hälsa: 1

#### Kråka
Primär attribut: Intelligens, 3 poäng.

Hälsa: 5

#### Mus Einstein
Primär attribut: Intellignes, 6 poäng.

Hälsa: 2

### Föremålskort

Stöter man på ett föremål så kan den ha olika negativa eller positiva effekter på din karaktär, nedan tänkte jag skriva några exempel på föremål som jag tänkte implementera, även dessa kort kan ändras för att få bättre balans på spelet, det kan även läggas till eller tas bort kort.

#### Helande ost
Din karaktär får full hälsa igen.

#### Möglig ost
Din karaktär förlorar 3 hälsopoäng.

#### Marsvinspellets med extra C-vitamin
Din karaktär får 3 styrka.

#### Spillt kaffepulver
Din karaktär får 3 smidighet.

#### Broschyr från Linnéuniversitetet
Din karaktär får 3 intelligens.

### Fällkort

Stöter man på en fälla så kan man undvika dom beroende på olika attribut din karaktär har. Undviker man dom inte måste man gå igenom dess konsekvenser.

#### Musfälla
Du går in i musfällan och tar 2 skada, om du inte slår med eller lika med din styrka och lyckas böja bort fällan.

#### Kvast-attack!
Du blir slagen av kvasten och tar 2 skada, om du inte slår med eller lika med din smidighet och lyckas undvika attacken.

#### Råttgift
Du äter giftet och tar 2 skada, om du inte slår med eller lika med din intelligens och lyckas undvika fällan.

## Ostrutan

Katten har en 10% chans att vakna första gången man plockar ost. Varje gång du väljer att stanna kvar och ta mer ost ökar risken för att katten vaknar med 10%. Vaknar katten så dör din karaktär och spelomgången är därmed slut. För varje gång du lyckas med att sno ost får du en slumpvald ost som ger olika mycket poäng (exempelvis parmesanost är mer värd än goudaost). När du väl väljer att inte riskera att katten vaknar igen så beger man sig tillbaka samma väg som man kom.

## There and back again...

När du till sist är hemma till ditt hål i väggen i huset så får du poäng beroende på hur mycket hälsa du har kvar samt hur mycket ost du har och av vilken sort osten är, vilket får den slutgiltiga poängsumman att reflektera din prestation både av tur och skicklighet.
