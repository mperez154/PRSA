using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;

namespace Automation.TestCases
{
    [TestFixture]
    class ReservationsTest : BaseTest
    {
        User user = new User();
        [Test, Order(3)]
        public void JoesCancelReservation()
        {
            //User user = new User();

            Confirmation.Cancel(driver).Click();
            Confirmation.CancelPopUp(driver).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement element;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            element = wait.Until(driver => Confirmation.ConfirmationNumber(driver));

            Assert.AreEqual("Reservation Canceled", Confirmation.ConfirmedMessage(driver).Text);
            validation.Add("Confirmation", Confirmation.ConfirmationNumber(driver).Text);
            validation.Add("Name", Confirmation.Name(driver).Text);
            validation.Add("Message", Confirmation.ConfirmedMessage(driver).Text);
            validation.Add("Price", Confirmation.Price(driver).Text);

        }

        [Test, Order(2)]
        public void JoesModifyReservation()
        {
            //User user = new User();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Confirmation.Modify(driver).Click();
            Confirmation.ModifyPopUp(driver).Click();
            ChooseRate.ReserveButton(driver).Click();

            ProvideInformation.FirstName(driver).SendKeys("Modify " + user.GetFirstName());
            ProvideInformation.LastName(driver).SendKeys(user.GetLastname());
            ProvideInformation.Address(driver).SendKeys(user.GetAddress());
            ProvideInformation.City(driver).SendKeys(user.GetCity() + Keys.Tab);
            ProvideInformation.State(driver).SendKeys(user.GetState());
            ProvideInformation.Zip(driver).SendKeys(user.GetZip());
            ProvideInformation.Phone(driver).SendKeys(user.GetPhone());
            ProvideInformation.Email(driver).SendKeys(Strngs.GetQAEmail());
            ProvideInformation.ReserveButton(driver).Click();   //Click 'Continue to Reservation' button

            // Confirmation Page
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement element;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            element = wait.Until(driver => Confirmation.ConfirmationNumber(driver));

            Assert.AreEqual("Reservation Modified", Confirmation.ConfirmedMessage(driver).Text);

            validation.Add("Confirmation", Confirmation.ConfirmationNumber(driver).Text);
            validation.Add("Name", Confirmation.Name(driver).Text);
            validation.Add("Message", Confirmation.ConfirmedMessage(driver).Text);
            validation.Add("Price", Confirmation.Price(driver).Text);
            
        }

        [Test, Order(1)]
        public void JoesCreateReservation()
        {
            //User user = new User();
            //Create Reservation URL
            FindAndReserve.GetSite(driver, Strngs.GetJoesParking());
            driver.Manage().Window.Size = new Size(1400, 900);

            //Location drop down arrow on Find & Reserve Page
            FindAndReserve.Location(driver).Click();

            //Select location
            FindAndReserve.LocationDropdown(driver).SendKeys(Keys.Down + Keys.Down);

            //Enter start date
            FindAndReserve.StartDate(driver).Clear();
            FindAndReserve.StartDate(driver).SendKeys(date.ToString(Strngs.GetDateFormat()) + Keys.Tab);

            //Enter end date
            FindAndReserve.EndDate(driver).Clear();
            FindAndReserve.EndDate(driver).SendKeys(date.Add(TimeSpan.FromDays(GetRandomNumber(1,5))).ToString(Strngs.GetDateFormat()));
            FindAndReserve.Discount(driver).Click();
            FindAndReserve.ContinueAsGuest(driver).Click(); //Click continue as guest

            //Choose Rate page
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(driver => ChooseRate.ReserveButton(driver));

            ChooseRate.ReserveButton(driver).Click();

            //Provide Information Page
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            element = wait.Until(driver => ProvideInformation.FirstName(driver));

            ProvideInformation.FirstName(driver).SendKeys(user.GetFirstName());
            ProvideInformation.LastName(driver).SendKeys(user.GetLastname());
            ProvideInformation.Address(driver).SendKeys(user.GetAddress());
            ProvideInformation.City(driver).SendKeys(user.GetCity() + Keys.Tab);
            ProvideInformation.State(driver).SendKeys(user.GetState());
            ProvideInformation.Zip(driver).SendKeys(user.GetZip());
            ProvideInformation.Phone(driver).SendKeys(user.GetPhone());
            ProvideInformation.Email(driver).SendKeys(Strngs.GetQAEmail());
            ProvideInformation.ReserveButton(driver).Click();   //Click 'Continue to Reservation' button

            // Confirmation Page
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            element = wait.Until(driver => Confirmation.ConfirmationNumber(driver));

            Assert.AreEqual("Reservation Confirmed", Confirmation.ConfirmedMessage(driver).Text);

            validation.Add("Confirmation", Confirmation.ConfirmationNumber(driver).Text);
            validation.Add("Name", Confirmation.Name(driver).Text);
            validation.Add("Message", Confirmation.ConfirmedMessage(driver).Text);
            validation.Add("Price", Confirmation.Price(driver).Text);

        }

        public void PaymentInfo()
        {
            // Element from Provide Info page
            driver.FindElement(By.Id("Reservation_CreditCardName")).Click();
            //driver.FindElement(By.Id("Reservation_CreditCardName")).SendKeys(firstName + " " + lastname);

            driver.FindElement(By.Id("Reservation_CreditCardNumber")).Click();
            driver.FindElement(By.Id("Reservation_CreditCardNumber")).SendKeys("5454545454545454");

            driver.FindElement(By.Id("Reservation_CreditCardCvv")).Click();
            driver.FindElement(By.Id("Reservation_CreditCardCvv")).SendKeys("123");

            driver.FindElement(By.Id("ReservationCreditCardExpirationMonth_hidden")).Click();
            driver.FindElement(By.Id("ReservationCreditCardExpirationMonth_hidden")).SendKeys("5");

            driver.FindElement(By.Id("ReservationCreditCardExpirationYear_hidden")).Click();
            driver.FindElement(By.Id("ReservationCreditCardExpirationYear_hidden")).SendKeys("2018");

            driver.FindElement(By.Id("Reservation_BillingAddress")).Click();
            //driver.FindElement(By.Id("Reservation_BillingAddress")).SendKeys(address);

            driver.FindElement(By.Id("Reservation_BillingCity")).Click();
            //driver.FindElement(By.Id("Reservation_BillingCity")).SendKeys(city);

            driver.FindElement(By.Id("ReservationBillingState_hidden")).Click();
            driver.FindElement(By.Id("ReservationBillingState_hidden")).SendKeys("F");

            driver.FindElement(By.Id("Reservation_BillingPostalCode")).Click();
            //driver.FindElement(By.Id("Reservation_BillingPostalCode")).SendKeys(zip);

            //driver.FindElement(By.Id("Reservation_OptCancelPolicy")).Click();
        }
    }
}
