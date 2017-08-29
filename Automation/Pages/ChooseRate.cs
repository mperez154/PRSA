using OpenQA.Selenium;
using Automation.Interfaces;

namespace Automation.Pages
{
    class ChooseRate: BasePage
    {
        public static IWebElement ReserveButton(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath("./*//*[@id='form0']/div/div/div[1]/div[2]/div[2]/input"));
               //                                    .//*[@id='form0']/div/div/div[1]/div[2]/div[2]/input
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
    }
}
