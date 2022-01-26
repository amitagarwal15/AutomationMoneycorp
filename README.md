# AutomationMoneycorp
Automation test assignment for Moneycorp.

Tools and Technology used:-
This aissgment is implemented using Selenium WebDriver with C#
Nunit has been used as testing framework.
Used Resharper to tun the test within Visual studio.

To execute this test on local machine
1. Download and install Visual Studio 2019 and GitHub or GitBash.
2. Clone repository from GitHub using URL https://github.com/amitagarwal15/AutomationMoneycorp.git
3. Download ChromeDriver required by your OS from https://chromedriver.storage.googleapis.com/index.html?path=98.0.4758.48/
4. Extract downloaded ChromeDriver zip file and Copy ChromeDriver,exe under D:\\drivers\\ folder as this path is given in App.config to launch the browser while running test.
5. Go to cloned repository location on locan machine then inside that double click on "AutomationMoneycorp.sln" file to open in Visual Studio
6. In Solution Explorer right click on Solution "AutomationMoneycorp" and select "Build Solution" option.
7. Downloadn and install Rehsrper from https://download.jetbrains.com/resharper/dotUltimate.2021.3.2/JetBrains.dotUltimate.2021.3.2.exe?_gl=1*anji4l*_ga*NTg2MTkzMTY3LjE2NDMxOTg3MzY.*_ga_V0XZL7QHEB*MTY0MzE5ODczNi4xLjEuMTY0MzE5ODc0Ni4w&_ga=2.54689195.1811967787.1643198736-586193167.1643198736

Note:-
If step 6 fails make sure enrty for "nuget.org" with source "https://www.nuget.org/api/v2/" is added in Package Sources and checkbox is marked as checked gainst it.
To verify this right clik on solution "AutomationMoneycorp" from solution explorer, select "Manage Nuget Packages for Solution" > Then Click on Gear icon on shown windoe and here we can verify if it is added or not.
If not, Click on + icon Enter "nuget.org" and enter "https://www.nuget.org/api/v2/" field > Click Update > OK.

If it still gives error, Make sure you have .NetFramework version 4.8 installed.

To Run the Test:-
1. Expand project AutomationMoneycorp in solution explorer.
2. Expand TestScripts folder.
3. Double click on MoneycorpTestFixture.cs
4. Run VerifyAllLinksInSearchResult test
