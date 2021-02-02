using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Learn_Specflow.Hooks
{
    [Binding]
    public sealed class Hook1
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private readonly IObjectContainer _objectContainer;
        private static IWebDriver _driver;
        //private static KlovReporter klov;
        private ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;

        public Hook1(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            SelectBrowser("Chrome");
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"F:\Projects\Learn_Specflow\Reports\TestReport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }

        [AfterStep]
        public void InsertReportingStep(ScenarioContext scenarioContext)
        {

            if (scenarioContext.TestError == null)
            {
                var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                else if (stepType == "And")
                    scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
            }

            Thread.Sleep(1000);  

        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _driver.Quit();
            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

       
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            //SelectBrowser(BrowserType.Chrome);
            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
           
        }


        private static void SelectBrowser(String browserType)
        {
            switch (browserType)
            {
                case "Chrome":
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService("webdriver.chrome.driver", @"F:\\Projects\\Learn_Specflow\\packages\\Selenium.WebDriver.ChromeDriver.87.0.4280.8800\\driver\\win32\\chromedriver.exe");
                    _driver = new ChromeDriver(service);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    _driver.Manage().Window.Maximize();
                    
                    break;
                default:
                    break;
            }
        }

        enum BrowserType
        {
            Chrome

        }
    }
}
