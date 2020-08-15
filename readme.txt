This solution is an example of a basic test automation framework using DotNetCore, C#, Selenium, and NUnit with test parallelization.

-- Architecture --
The automation framework is a project isolated from any systems under test.
The automation framework hosts the WebDriver used for controlling the browser (chrome in this example).
There is a helpers folder that contains the BasePage class which is all basic operations the driver will be performing upon any system under test.

The system(s) under test (SUT) is a project that references the automation framework.
In this example the SUT is an open website hosted by SauceLabs for anyone to practice test automation on (https://www.saucedemo.com/).
The SUT is a shopping platform where users can add items to their cart and checkout.
The basic SUT architecture used for this example is page object models (POM), page logic (Pages), and tests (Tests).
The POM contains a skeleton of all the major elements on a page that the test automation will interact with.
This allows for easy maintainability and access to these page elements.
Pages contain all the logic that our tests will use for interacting with the SUT. Entering data, validating fields, etc. will all be done through Pages.
All of the tests for the SUT are located in the Tests folder. This folder, like all other folders in the SUT are organized based on what page is being interacted with. 
There is an Initialization class in the Tests folder which is the entry point for all test runs in the SUT.
This initialization class uses NUnit and is how the Driver class gets initialized from our automation framework.

-- Running Tests --
Tests can be found in the Test Explorer (in Visual Studio). 
This framework is set up for running multiple tests at once (parallelization). Select what tests you wish to run, right-click on them and click Run.
Parallelization works based off of how many CPU cores your computer has. If you have 4 cores you will be able to run up to 4 tests at a time.
Some of the tests will fail due to bugs in the SUT.

Note: The chromedriver.exe version must match your Chrome version. You may need to replace the chromedriver.exe in the Framework/Selenium folder with a current version. You can find the latest chromedriver here: https://chromedriver.chromium.org/downloads
