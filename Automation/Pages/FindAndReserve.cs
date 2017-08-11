using OpenQA.Selenium;
using Automation.Interfaces;

namespace Automation.Pages
{
    class FindAndReserve: BasePage
    {
        public static IWebElement Location(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRates"));
            return element;
        }

        public static IWebElement LocationDropdown(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='ShopRates']/div[1]/ul/li[3]"));
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
    }
}