using OpenQA.Selenium;
using Automation.Interfaces;

namespace Automation.Pages
{
    class ChooseRate: BasePage
    {
        public static IWebElement ReserveButton(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath("./*//*[@id='form0']/div/div/div[1]/div[2]/div[2]/input"));
            return element;
        }
    }
}
