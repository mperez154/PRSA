using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace Automation
{
    class NUnitTest
    {
        IWebDriver driver;
        [SetUp]
        public void TestApp()
        {
            driver = new FirefoxDriver();
        }
        [Test]
        public void OpenSite()
        {
            driver.Url = "http://www.google.com";
        }
        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
