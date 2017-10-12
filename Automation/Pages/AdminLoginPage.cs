using Automation.Interfaces;
using OpenQA.Selenium;
using System.Drawing;

namespace Automation.Pages
{
    class AdminLoginPage : BasePage
    {
        public static IWebElement Header(IWebDriver driver)
        {
            element = driver.FindElement(By.ClassName("sign-in-heading"));
            return element;
        }

        public static IWebElement UserLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[1]/label"));
            return element;
        }

        public static IWebElement PasswordLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[2]/label"));
            return element;
        }

        public static IWebElement UserField(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Email"));
            return element;
        }

        public static IWebElement PasswordField(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Password"));
            return element;
        }

        public static IWebElement LoginButton(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[3]/div/input"));
            return element;
        }
    }
}
