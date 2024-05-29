# DcHRallyProject
<sub>**Projekt Rally Lydighed af Team 13** bestående af Sebastian Engberg Riis Sørensen, Søren Skov Andersen, Minik Busk Langkjær og Tobias Kjær.</sub>

<sub>**OBS:** Man skal være på **VPN** for at køre programmet, da applikationen benytter vores UCL Team Database.</sub>

## **Overblik over projektet**

Vores applikation er designet til entusiaster af **Hunde Rally Lydighed**, hvor brugere kan bygge og opdatere deres egne baner. Systemet tilbyder en brugervenlig platform for instruktører og dommere til at administrere deres træningsbaner og konkurrencer. For at se en demonstration af applikationen, kan du se vores **videodemonstration** her.

[Se Team 13's Video Demonstration Her!](https://drive.google.com/file/d/19OH9zweXwlnJ_ADzK0mOfgE-FV8ogAuh/view?usp=sharing)

## **Systemudvikling**

Vi identificerede og håndterede **komplekse udfordringer** og **usikkerheder** i projektet, hvilke hjalp os med at vælge en **procesmodel**. Vores tilgang begyndte med **cyklisk procesmodel**, der førte til valget af **systemudviklingsmetoden Crystal Methods**, som vi arbejdede med over en 4-ugers periode for at optimere vores udviklingsproces. Vi anvendte **SCRUM** til agil projektstyring og **Gantt-diagrammer** til tidsplanlægning. Efter at have opnået større klarhed over projektets usikkerheder skiftede vi systemudviklingsmetode til en **vandfaldsmodel med løbende feedback**. For at sikre en sikker udviklingsproces udledte vi **misbrugstilfælde** og arbejdede med **trusselsmodellering** og **risikostyring**. Til sidst overvejede vi forskellige strategier for **udrulning** og **vedligehold**, herunder Pilot Cutover og Bing Bang.

## **Programmering og Teknologi**

Systemet er udviklet som en **ASP.NET Core MVC applikation** i .NET 8.0. Vi brugte **HTML**, **CSS**, og **JavaScript** (Konva.js) til at skabe interaktive banebyggerfunktioner. Applikationen benytter **dynamisk renderede HTML-sider** med **Razor Pages** og **CSS** til styling, samt **JavaScript** til at bygge en interaktiv banebygger med **drag-and-drop funktionalitet** ved hjælp af JS frameworket Konva.js. Instanserne kommunikerer ved hjælp af **standard protokoller som JSON**. Brugere kan oprette profiler og logge ind, hvor systemet håndterer **autentifikation** og **autorisation** ved hjælp af **ASP.NET Core Identity** og tildeling af **roller**. Al data gemmes i en **database** og er implementeret med **EF Core Migrations** via en Code-first approach. Vi sikrede kvaliteten af vores kode med løbende **unit tests** og **integrationstests**.

## **Sammenfatning**

Gennem dette projekt har vi opnået erfaring med forskellige **systemudviklingsmetoder**, **distribuerede systemer** og integration af nye teknologier inden for **ASP.NET Core** og **webudvikling**. Dette har givet os en dybere forståelse af, hvordan forskellige teknologier og metoder kan komplementere hinanden i udviklingen af komplekse systemer.
