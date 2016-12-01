# Projektstandarder

## Utvecklingsmiljö
Projektet använder Git för versionshantering, med GitHub som centralt
repository. Waffle används som scrum board för att hantera projektets backlog
och sprintplanering.

## Definition of Done
Projektets DoD definieras i detta dokument, och skall finnas som ett kort i
Done-kolumnen på vår scrum board som en referens.
-   Alla tester ska fungera
-   Ändringar i databasen ska ha migrationer skapade och incheckade
-   Code Review av user stories ska vara utförd
-   Humangränssnittet ska vara testat

## Versionering av projektet
Projektet använder [Semantic Versioning 2.0.0][semver] för att definiera
projektetsversionsnummer.
-   **Major version:** ej definierad
-   **Minor version:** efter en godkänd demonstration för produktägaren mergas
    demo-koden till master, och minor version ökas.
-   **Patch version:** hotfixes på master-grenen ökar patch version.

## Grenar i Git
-   `master` -- Denna gren innehåller kod som ska vara garanterat körbar, testad
    och buggfri. Detta är den kod som körs i produktion av kunden efter en
    leverans. Endast `demo` och `develop` får mergas in i `master`, samt
    eventuella hotfixes. Merge-commiten taggas med en releaseversion, ex
    "v0.18.1", enligt [Semantic Versioning][semver], med en tag som pushas till
    projektets centrala repository.
-   `develop` -- Grenen där all utveckling sker. Teamet grenar av feature
    branches för lokalt arbete, och mergar in dessa i develop då de är färdiga
    med respektive feature enligt Definition of Done. När kodbasen i develop
    uppnått leveranskvalitet kan den mergas till demo för en demonstration för
    produktägare/kund, eller master om den är godkänd för leverans.
-   `demo` -- En gren för kod som är färdig att levereras genom att mergas till
    `master` efter att produktägaren godkänt demot. Endast `develop` får mergas
    in i denna gren. Om koden godkänns av PO/kund kan den mergas till `master`.
-   Feature-branches -- Teamet grenar av develop lokalt för att arbeta på sina
    respektive uppgifter, och mergar sedan in sin feature branch i `develop` då
    de arbetat klart på uppgiften enligt Definition of Done. Grenarna bör hållas
    lokala men går även att pusha till projektets centrala repository för att
    tex arbeta med uppgiften på flera datorer, eller söka assistans av annan
    teammedlem.
-   `hotfix` -- om en kritisk bugg uppstår i levererad kod i `master`-grenen,
    skapas en ny hotfix-gren från master-grenen, där buggen åtgärdas, och sedan
    mergas tillbaka in i `master` som en ny patch-version. Denna gren ska
    därefter även mergas in i `develop` för eventuell förbättring och korrekt
    integration i kodbasen.

Se [Gitflow Workflow][gitflow] för mer information om detta arbetsflöde.

## Databas
Projektet använder sig av Code First-konventioner med Entity Framework.
Ändringar i databasens struktur ska versionshanteras genom att en migration med
ändringarna skapas. Migrationer ska innehålla både up/down-definitioner för att
kunna återgå till en tidigare version.

Definitionen av databasen i koden är den auktoritära definitionen av databasen,
och ER-diagram genereras utifrån koden.

Separata databaser ska användas för utveckling, testande och demonstration, där
test-databasen innehåller gemensam data så att teamet testar mot samma data.

Om vi upptäcker att vi behöver fler fält i databasen, ska detta hanteras som en
separat issue/story som omgående mergas in i develop, så att resten av teamet
snabbt kan ta del av ändringarna i databasen.

## Demonstrationsmiljö
För demonstrationssyften används `demo`-grenen i vårt git-repository. Denna kod
deployas till Azure för en separat demonstrationsmiljö.

[gitflow]:https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow/
[semver]:http://semver.org/lang/sv/
