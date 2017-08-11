using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using Automation.Data;

namespace Automation.Interfaces
{
    class BaseTest
    {
        public ExtentReports report;
        public ExtentTest test;
        public IWebDriver driver;
        public static string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string actualPath = path.Substring(0, path.LastIndexOf("bin"));
        public static string projectPath = new Uri(actualPath).LocalPath;
        public static DateTime date = DateTime.Now;
        public string today = "" + date.Month + date.Day + date.Year + date.Hour + date.Minute;
        public Dictionary<string, string> validation = new Dictionary<string, string>();

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();

            //Report path setup
            string reportPath = projectPath + "Reports\\AutomationReport_" + today + ".html";
            //string reportPath = projectPath + "Reports\\AutomationReport.html";

            //Report initialization
            report = new ExtentReports(reportPath, false);
            
            //Report Configuration
            report.LoadConfig(projectPath + "extent-config.xml");
            test = report.StartTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void EndTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                test.Log(LogStatus.Fail, "Failed");
                test.Log(LogStatus.Info, errorMessage);
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(projectPath + "Reports\\Failed_" + TestContext.CurrentContext.Test.Name + "_"  + today + ".png", ScreenshotImageFormat.Png);
                test.Log(LogStatus.Info, "See Screenshot" + test.AddScreenCapture(".\\Failed_" + TestContext.CurrentContext.Test.Name + "_" + today + ".png"));
            }
            else
            {
                test.Log(LogStatus.Pass, "Passed");
                foreach(KeyValuePair<string, string> pair in validation)
                {
                    test.Log(LogStatus.Info, pair.Key + ":  " + pair.Value);
                }
            }
            driver.Quit();
            report.EndTest(test);
            report.Flush();
            report.Close();
        }
        public static int GetRandomNumber(int start, int end)
        {
            Random random = new Random();
            int myNumber = random.Next(start, end);
            return myNumber;
        }
    }
}