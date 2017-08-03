using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Automation.Pages
{
    class HomePg
    {
        static private IWebElement element;

        public static void GetSite(IWebDriver driver)
        {
            //driver.Url = "http://www.google.com";
            driver.Url = "http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542";
        }

        public static IWebElement Location(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRates"));
            return element;
        }

        public static IWebElement StartDate(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRatesStartDate"));
            return element;
        }

        public static IWebElement EndDate(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRatesEndDate"));
            return element;
        }

        public static IWebElement Discount(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRates_DiscountPromo"));
            return element;
        }

        public static IWebElement LocationLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[1]/div[1]/span/label"));
            return element;
        }

        public static IWebElement StartDateLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[2]/div[1]/span/label"));
            return element;
        }

        public static IWebElement EndDateLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[3]/div[1]/span/label"));
            return element;
        }

        public static IWebElement DiscountLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[4]/div[1]/span/label"));
            return element;
        }

        public static IWebElement ContinueAsMember(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[5]/div[1]/input"));
            return element;
        }

        public static IWebElement ContinueAsGuest(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[5]/div[2]/input"));
            return element;
        }

        public static IWebElement Header(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/h1"));
            return element;
        }

        public static string Title(IWebDriver driver)
        {
            string title = driver.Title;
            return title;
        }


    }
}
