using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;

namespace Automation.TestCases
{
    class FindReserveTest: BaseTest
    {
        [Test, Property("Priority", 1)]
        public void MyFirstTest()
        {
            //Should pass
            FindAndReserve.GetSite(driver, strngs.getCreateReservationPage());
            Assert.AreEqual("http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542", driver.Url);
            Assert.AreEqual("WallyPark Reservations", driver.Title);
        }

        [Test, Property("Priority", 2)]
        public void MySecondTest()
        {
            //Should Fail
            FindAndReserve.GetSite(driver, strngs.getCreateReservationPage());
            Assert.AreEqual("www.google.com", driver.Url);
        }
    }
}
