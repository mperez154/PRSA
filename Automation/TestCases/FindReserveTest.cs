using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;

namespace Automation.TestCases
{
    class FindReserveTest: BaseTest
    {
        [Test, Property("Priority", 1)]
        public void validateURL()
        {
            //Should pass
            FindAndReserve.GetSite(driver, strngs.getReservationPage());
            Assert.AreEqual("http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542", driver.Url);          
        }

        [Test, Property("Priority", 2)]
        public void validateTitle()
        {
            //Should Fail
            FindAndReserve.GetSite(driver, strngs.getReservationPage());
            Assert.AreEqual("WallyPark Reservation Fail", driver.Title);
        }
    }
}
