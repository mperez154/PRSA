using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;
using System;
using OpenQA.Selenium;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Automation.TestCases
{
    class TimeDateTests : BaseTest
    {
        DateTime date = DateTime.Today.Add(TimeSpan.FromDays(GetRandomNumber(14, 28)));
        User user = new User();

        [Test, Order(1)]
        public void TimeDate_FindAndReservePage()
        {
            // Open Site
            FindAndReserve.GetSite(driver, FindAndReserve.GetReservationURL("Staging", "Joes"));
            driver.Manage().Window.Size = new Size(1750, 1050);

            // Select location
            FindAndReserve.Location(driver).Click();
            FindAndReserve.LocationDropdown(driver).SendKeys(Keys.Down + Keys.Down + Keys.Tab);
            
            //Enter start date, then validate   
            FindAndReserve.StartDate(driver).SendKeys(date.ToString("g") + Keys.Tab);
            Assert.AreEqual(date.ToString("g"), FindAndReserve.StartDate(driver).GetAttribute("value"));

            //Enter end date
            date = date.Add(TimeSpan.FromDays(5));
            FindAndReserve.EndDate(driver).SendKeys(date.ToString("g") + Keys.Tab);
            Assert.AreEqual(date.ToString("g"), FindAndReserve.EndDate(driver).GetAttribute("value"));

            validation.Add("Start Date", FindAndReserve.StartDate(driver).GetAttribute("value"));
            validation.Add("End Date", FindAndReserve.EndDate(driver).GetAttribute("value"));

            FindAndReserve.ContinueAsGuest(driver).Click();
        }

        [Test, Order(2)]
        public void TimeDate_ChooseRate()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(driver => ChooseRate.ReserveButton(driver));

            date = date.Subtract(TimeSpan.FromDays(5));
            Assert.AreEqual(date.ToString("g"), ChooseRate.StartDate(driver).GetAttribute("value"));
            validation.Add("Start Date", ChooseRate.StartDate(driver).GetAttribute("value"));

            date = date.Add(TimeSpan.FromDays(5));
            Assert.AreEqual(date.ToString("g"), ChooseRate.EndDate(driver).GetAttribute("value"));
            validation.Add("End Date", ChooseRate.EndDate(driver).GetAttribute("value"));

            ChooseRate.ReserveButton(driver).Click();
        }

        [Test, Order(3)]
        public void TimeDate_ProvideInfo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(driver => ProvideInformation.FirstName(driver));

            //string test = ProvideInformation.StartDate(driver).Text;
            //int testLength = test.Length;
            //test = test.Remove(testLength - 6, 3);

            date = date.Subtract(TimeSpan.FromDays(5));
            Assert.AreEqual(date.ToString("g"), ProvideInformation.StartDate(driver).Text.Remove(ProvideInformation.StartDate(driver).Text.Length - 6, 3));
            validation.Add("Start Date", ProvideInformation.StartDate(driver).Text.Remove(ProvideInformation.StartDate(driver).Text.Length - 6, 3));

            date = date.Add(TimeSpan.FromDays(5));
            Assert.AreEqual(date.ToString("g"), ProvideInformation.EndDate(driver).Text.Remove(ProvideInformation.EndDate(driver).Text.Length - 6, 3));
            validation.Add("End Date", ProvideInformation.EndDate(driver).Text.Remove(ProvideInformation.EndDate(driver).Text.Length - 6, 3));

            ProvideInformation.FirstName(driver).SendKeys(user.GetFirstName());
            ProvideInformation.LastName(driver).SendKeys(user.GetLastname());
            ProvideInformation.Email(driver).SendKeys("ozerep154+automation@gmail.com");
            ProvideInformation.Phone(driver).SendKeys(user.GetPhone());
            ProvideInformation.ReserveButton(driver).Click();
        }
        [Test, Order(4)]
        public void TimeDate_Confirmation()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(driver => Confirmation.ConfirmationNumber(driver));
            
            validation.Add("Date Range", Confirmation.DateField(driver).Text);
        }

        [Test, Order(5)]
        public void TimeDate_Database()
        {
            Reservation reservation = new Reservation();
            Dictionary<int,string> test = reservation.GetReservationDates((Int32.Parse(Confirmation.ConfirmationNumber(driver).Text)));
            //foreach (KeyValuePair<int, string> pair in test)
            //{
            //    Console.Write(pair.Key + ":  " + pair.Value + "\n");
            //}        

            date = date.Subtract(TimeSpan.FromDays(5));
            Assert.AreEqual(date.ToString("g"), test[1].Remove(test[1].Length -6, 3));
            validation.Add("Start Date", test[1].Remove(test[1].Length - 6, 3));

            date = date.Add(TimeSpan.FromDays(5));
            Assert.AreEqual(date.ToString("g"), test[2].Remove(test[2].Length - 6, 3));
            validation.Add("End Date", test[2].Remove(test[2].Length - 6, 3));

        }
    }
}
