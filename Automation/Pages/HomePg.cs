using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Automation.Pages
{
    class HomePg
    {
        static private IWebElement element;

        public static void GetSite(IWebDriver driver)
        {
            driver.Url = "http://www.google.com";
        }

        public static IWebElement Amount(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("abc"));
            return element;
        }
    }
}
