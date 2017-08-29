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
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div[1]/div[2]/div[2]/div[2]/div[1]"));
            return element;
        }
        public static IWebElement Modify(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='quickActionInner']/a[2]"));
            return element;
        }
        public static IWebElement ModifyPopUp(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='modifyReservationModal']/div/div[2]/div[2]/div/input"));
            return element;
        }
        public static IWebElement Cancel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='quickActionInner']/a[3]"));
            return element;
        }
        public static IWebElement CancelPopUp(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='cancelReservationModal']/div/div[2]/div[2]/div/input"));
            return element;
        }
        public static IWebElement DateField(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div[1]/div[2]/div[2]/div[1]/div[8]/div[2]"));
            return element;
        }
    }
}
