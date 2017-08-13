using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Windows;

namespace Automation.TestCases
{
    class ReservationsTest : BaseTest
    {
        [Test, Property("Priority", 1), Ignore("Skipping for now")]
        public void JoesCancelReservation()
        {
            User user = new User();
           
            FindAndReserve.GetSite(driver, strngs.GetReservationPage());
            Assert.AreEqual("http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542", driver.Url);
        }

        [Test, Property("Priority", 2), Ignore("Skipping for now")]
        public void JoesModifyReservation()
        {
            User user = new User();
            Console.Write("Consumer ID: " + user.GetConsumerID() + "\n");
            Console.Write("Name: " + user.GetFirstName() + " " + user.GetLastname() + "\n");
            Console.Write("Username: " + user.GetUsername() + "\n");
            Console.Write("Password: " + user.GetPassword() + "\n");
            //Should Fail
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //FindAndReserve.GetSite(driver, strngs.GetReservationPage());
            //Assert.AreEqual("WallyPark Reservation Fail", driver.Title);
        }

        [Test, Property("Priority", 1), Repeat(1)]
        public void JoesCreateReservation()
        {
            User user = new User();
            //Create Reservation URL
            FindAndReserve.GetSite(driver, strngs.GetJoesParking());
            driver.Manage().Window.Size = new Size(1400, 900);

            //Location drop down arrow on Find & Reserve Page
            FindAndReserve.Location(driver).Click();

            //Select location
            FindAndReserve.LocationDropdown(driver).SendKeys(Keys.Down + Keys.Down);

            //Enter start date
            FindAndReserve.StartDate(driver).Clear();
            FindAndReserve.StartDate(driver).SendKeys(date.ToString(strngs.GetDateFormat()) + Keys.Tab);

            //Enter end date
            FindAndReserve.EndDate(driver).Clear();
            FindAndReserve.EndDate(driver).SendKeys(date.Add(TimeSpan.FromDays(GetRandomNumber(1,5))).ToString(strngs.GetDateFormat()));
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
            ProvideInformation.Email(driver).SendKeys(strngs.GetQAEmail());
            ProvideInformation.ReserveButton(driver).Click();   //Click 'Continue to Reservation' button

            // Confirmation Page
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            element = wait.Until(driver => Confirmation.ConfirmationNumber(driver));

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
