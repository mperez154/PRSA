using Automation.Interfaces;
using Automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation.TestCases.Pages
{
    class AdminTest : BaseTest
    {
        [Test, Order(1)]
       public void ButtonsOnAdminLoginPage()
        {
            AdminLoginPage.OpenAdminSite(driver);
            Assert.AreEqual("Sign In", AdminLoginPage.LoginButton(driver).GetAttribute("value").ToString());
            validation.Add("Button Text", AdminLoginPage.LoginButton(driver).GetAttribute("value").ToString());
        }

        [Test, Order(2)]
        public void LabelsOnAdminLoginPage()
        {
            Assert.AreEqual("Email Address", AdminLoginPage.UserLabel(driver).Text);
            Assert.AreEqual("Password", AdminLoginPage.PasswordLabel(driver).Text);

            validation.Add("Email Label", AdminLoginPage.UserLabel(driver).Text);
            validation.Add("Pasword Label", AdminLoginPage.PasswordLabel(driver).Text);
        }

        [Test, Order(3)]
        public void HeaderOnAdminLoginPage()
        {
            Assert.AreEqual("Sign in to your account", AdminLoginPage.Header(driver).Text);
            validation.Add("Header", AdminLoginPage.Header(driver).Text);
        }

        [Test, Order(4)]
        public void TabsOnAdminPage()
        {
            //AdminLoginPage.OpenAdminSite(driver);
            AdminLoginPage.UserField(driver).SendKeys("hstprtuserWP@test.com");
            AdminLoginPage.PasswordField(driver).SendKeys("Temp!1234");
            AdminLoginPage.LoginButton(driver).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element;
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/nav/div/div[5]/ul/li[2]/a")));

            /*  Need to use list iterator & comparator to retrieve correct tabs
             *  From DB, then retrieve correct tabs from UI, then with the
             *  Comparator compare the two lists to ensure it's correct
             */

            //Assert.AreEqual("Channels", element.GetAttribute("innerText"));
            //validation.Add("Tab", element.GetAttribute("innerText"));
        }
    }
}
