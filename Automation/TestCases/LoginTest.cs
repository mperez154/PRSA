using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;

namespace Automation.TestCases
{
    class LoginTest: BaseTest
    {
        [Test, Property("Priority", 1)]
        public void MyFirstTest()
        {
            //Should pass
            FindAndReserve.GetReservationPage(driver);
            Assert.AreEqual("http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542", driver.Url);
            Assert.AreEqual("WallyPark Reservations", driver.Title);
        }

        [Test, Property("Priority", 2)]
        public void MySecondTest()
        {
            //Should Fail
            FindAndReserve.GetReservationPage(driver);
            Assert.AreEqual("www.google.com", driver.Url);
        }
    }
}
