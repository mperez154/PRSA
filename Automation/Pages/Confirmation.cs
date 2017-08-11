using OpenQA.Selenium;
using Automation.Interfaces;

namespace Automation.Pages
{
    class Confirmation: BasePage
    {
        public static IWebElement ConfirmedMessage(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div[1]/div[2]/h3"));
            return element;
        }

        public static IWebElement ConfirmationNumber(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div[1]/div[2]/div[2]/div[1]/div[5]/div[2]"));
            return element;
        }
        public static IWebElement Name(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]"));
            return element;
        }
        
        public static IWebElement Price(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='itemizedChargesTableContainer']/table/tbody/tr[7]/td[2]"));
            return element;
        }
    }
}
