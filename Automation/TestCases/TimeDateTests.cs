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
        //public DateTime date = DateTime.Today.Add(TimeSpan.FromDays(GetRandomNumber(14, 28)));

        [Test, Property("Priority", 1), Ignore("Not Needed")]
        public void TimeDate_FindAndReservePage()
        {
            User user = new User();
            
            // Open Site
            FindAndReserve.GetSite(driver, Strngs.GetJoesParking());

            // Select location
            FindAndReserve.Location(driver).Click();
            FindAndReserve.LocationDropdown(driver).SendKeys(Keys.Down + Keys.Tab);
            
            //Enter start date, then validate   
            FindAndReserve.StartDate(driver).SendKeys(date.ToString(Strngs.GetDateFormat()) + Keys.Tab);
            Assert.AreEqual(date.ToString(Strngs.GetDateFormat()), FindAndReserve.StartDate(driver).GetAttribute(Strngs.GetAttribute()));

            //Enter end date
            date = date.Add(TimeSpan.FromDays(5));
            FindAndReserve.EndDate(driver).SendKeys(date.ToString(Strngs.GetDateFormat()) + Keys.Tab);
            Assert.AreEqual(date.ToString(Strngs.GetDateFormat()), FindAndReserve.EndDate(driver).GetAttribute(Strngs.GetAttribute()));

            validation.Add("Start Date", FindAndReserve.StartDate(driver).GetAttribute(Strngs.GetAttribute()));
            validation.Add("End Date", FindAndReserve.EndDate(driver).GetAttribute(Strngs.GetAttribute()));
        }
    }
}
