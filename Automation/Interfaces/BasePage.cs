using OpenQA.Selenium;

namespace Automation.Interfaces
{
    class BasePage
    {
        public static IWebElement element;

        public static void GetSite(IWebDriver driver, string url)
        {
            driver.Url = url;
        }

        public static string Title(IWebDriver driver)
        {
            return driver.Title;
        }
    }
}
