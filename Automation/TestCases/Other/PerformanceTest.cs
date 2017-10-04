using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using Automation.TestCases;

namespace Automation.TestCases
{
    class PerformanceTest: PerformanceBase
    {
        User user = new User();

        [Test, Repeat(1)]
        public void WPPerformanceTest()
        {
            JoesPerformanceCreate();
            JoesPerformanceModify();
            JoesPerformanceCancel();
        }

        public void JoesPerformanceCancel()
        {
            //Confirmation Page
            Confirmation.Cancel(driver).Click();
            Confirmation.CancelPopUp(driver).Click();

            // Confirmation Page (Afer clicking Cancel)
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Boolean element = wait.Until(driver => Confirmation.ConfirmedMessage(driver).Text.Contains("Canceled"));

            Assert.AreEqual("Reservation Canceled", Confirmation.ConfirmedMessage(driver).Text);
            validation.Add("Cancelled #", Confirmation.ConfirmationNumber(driver).Text);
            validation.Add("Cancelled Name", Confirmation.Name(driver).Text);
            validation.Add("Cancelled Message", Confirmation.ConfirmedMessage(driver).Text);
            validation.Add("Cancelled Price", Confirmation.Price(driver).Text);
        }

        public void JoesPerformanceModify()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element;

            //Confirmation Page
            Confirmation.ClickModify(driver);

            //Choose Rate page
            element = wait.Until(driver => ChooseRate.ReserveButton(driver));
            ChooseRate.ClickReserve(driver);

            //Provide Information Page
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Reservation_FirstName")));

            //Payment Info
            ProvideInformation.PaymentInfo(driver, user);
            ProvideInformation.ClickReserve(driver);   //Click 'Continue to Reservation' button

            // Confirmation Page
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            element = wait.Until(driver => Confirmation.ConfirmationNumber(driver));

            Assert.AreEqual("Reservation Modified", Confirmation.ConfirmedMessage(driver).Text);

            validation.Add("Modify #", Confirmation.ConfirmationNumber(driver).Text);
            validation.Add("Modify Name", Confirmation.Name(driver).Text);
            validation.Add("Modify Message", Confirmation.ConfirmedMessage(driver).Text);
            validation.Add("Modify Price", Confirmation.Price(driver).Text);
        }

        public void JoesPerformanceCreate()
        {
            //Find & Reserve Page
            FindAndReserve.OpenSite(driver, "QA", "WallyPark");
            FindAndReserve.StartReservation(driver, date);

            //Choose Rate page
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(driver => ChooseRate.ReserveButton(driver));
            ChooseRate.ClickReserve(driver);

            //Provide Information Page
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Reservation_FirstName")));
            ProvideInformation.UserInfo(driver, user);

            //Payment Info
            ProvideInformation.PaymentInfo(driver, user);
            ProvideInformation.ClickReserve(driver);   //Click 'Continue to Reservation' button

            // Confirmation Page
            element = wait.Until(driver => Confirmation.ConfirmationNumber(driver));

            Assert.AreEqual("Reservation Confirmed", Confirmation.ConfirmedMessage(driver).Text);

            validation.Add("Reservation #", Confirmation.ConfirmationNumber(driver).Text);
            validation.Add("Reservation Name", Confirmation.Name(driver).Text);
            validation.Add("Reservation Message", Confirmation.ConfirmedMessage(driver).Text);
            validation.Add("Reservation Price", Confirmation.Price(driver).Text);
            validation.Add("Reservation Dates", Confirmation.DateField(driver).Text);
        }


    }
}
