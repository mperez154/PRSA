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
            Assert.AreEqual("http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542", driver.Url);
            Assert.AreEqual("WallyPark Reservations", driver.Title);
        }

        [Test, Property("Priority", 2)]
        public void MySecondTest()
        {
            //Should Fail
            HomePg.GetSite(driver);
            Assert.AreEqual("www.google.com", driver.Url);
        }
    }
}
