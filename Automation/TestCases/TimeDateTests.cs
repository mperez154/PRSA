using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Automation.TestCases
{
    class TimeDateTests : BaseTest
    {
        [Test, Property("Priority", 1)]
        public void TimeDate_FindAndReservePage()
        {
            User user = new User();
            DateTime date = DateTime.Today;

            // Open Site
            FindAndReserve.GetSite(driver, strngs.GetReservationPage());

            // Select location
            driver.FindElement(By.Id("ShopRates")).Click();
            driver.FindElement(By.XPath(".//*[@id='ShopRates']/div[1]/ul/li[3]")).SendKeys(Keys.Down + Keys.Tab);

            //Enter start date
            date = date.Add(TimeSpan.FromDays(GetRandomNumber()));
            driver.FindElement(By.Id("ShopRatesStartDate")).SendKeys(date.ToString() + Keys.Tab);

            // Validate entry has correct time & date
            Assert.AreEqual(date.ToString(), driver.FindElement(By.Id("ShopRatesStartDate")).GetAttribute("value"));
            
            //Enter end date
            date = date.Add(TimeSpan.FromDays(1));
            driver.FindElement(By.Id("ShopRatesEndDate")).Clear();
            driver.FindElement(By.Id("ShopRatesEndDate")).SendKeys(date.ToString());

            Thread.Sleep(5000);
                      
            // Validate entry has correct time & date
            Assert.AreEqual(date, driver.FindElement(By.Id("ShopRatesEndDate")).Text);
        }

        public int GetRandomNumber()
        {
            Random random = new Random();
            int myNumber = random.Next(14, 28);
            return myNumber;
        }
    }
}
