using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;
using System;
using OpenQA.Selenium;

namespace Automation.TestCases
{
    class TimeDateTests : BaseTest
    {
        new DateTime date = DateTime.Today.Add(TimeSpan.FromDays(GetRandomNumber(14, 28)));

        [Test, Property("Priority", 1)]
        public void TimeDate_FindAndReservePage()
        {
            User user = new User();
            
            // Open Site
            FindAndReserve.GetSite(driver, strngs.GetJoesParking());

            // Select location
            FindAndReserve.Location(driver).Click();
            FindAndReserve.LocationDropdown(driver).SendKeys(Keys.Down + Keys.Tab);
            //driver.FindElement(By.Id("ShopRates")).Click();
            //driver.FindElement(By.XPath(".//*[@id='ShopRates']/div[1]/ul/li[3]")).SendKeys(Keys.Down + Keys.Tab);

            //Enter start date, then validate   
            FindAndReserve.StartDate(driver).SendKeys(date.ToString(strngs.GetDateFormat()) + Keys.Tab);
            //driver.FindElement(By.Id("ShopRatesStartDate")).SendKeys(date.ToString(strngs.GetDateFormat()) + Keys.Tab);
            Assert.AreEqual(date.ToString(strngs.GetDateFormat()), FindAndReserve.StartDate(driver).GetAttribute(strngs.GetAttribute()));

            //Enter end date
            date = date.Add(TimeSpan.FromDays(GetRandomNumber(1, 5)));
            FindAndReserve.EndDate(driver).SendKeys(date.ToString(strngs.GetDateFormat()) + Keys.Tab);
            //driver.FindElement(By.Id("ShopRatesEndDate")).SendKeys(date.ToString(strngs.GetDateFormat()) + Keys.Tab);
            Assert.AreEqual(date.ToString(strngs.GetDateFormat()), FindAndReserve.EndDate(driver).GetAttribute(strngs.GetAttribute()));

            validation.Add("Start Date", FindAndReserve.StartDate(driver).GetAttribute(strngs.GetAttribute()));
            validation.Add("End Date", FindAndReserve.EndDate(driver).GetAttribute(strngs.GetAttribute()));
        }
    }
}
