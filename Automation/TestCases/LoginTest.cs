using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Automation.Pages;
using Automation.Interfaces;

namespace Automation.TestCases
{
    class LoginTest: Base
    {
        [Test, Property("Priority", 1)]
        public void MyFirstTest()
        {
            //Should pass
            HomePg.GetSite(driver);
            Assert.AreEqual("https://www.google.com/?gws_rd=ssl", driver.Url);
            Assert.AreEqual("Google", driver.Title);
        }

        [Test, Property("Priority", 2)]
        public void MySecondTest()
        {
            //Should Fail
            HomePg.GetSite(driver);
            Assert.AreEqual("www.google.co", driver.Url);
        }
    }
}
