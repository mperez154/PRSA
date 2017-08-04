using OpenQA.Selenium;

namespace Automation.Interfaces
{
    class BasePage
    {
        public static IWebElement element;

        public static void GetReservationPage(IWebDriver driver)
        {
            driver.Url = "http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542";
        }

        public static string Title(IWebDriver driver)
        {
            string title = driver.Title;
            return title;
        }
    }
}
