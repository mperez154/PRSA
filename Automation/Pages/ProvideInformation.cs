using OpenQA.Selenium;
using Automation.Interfaces;

namespace Automation.Pages
{
    class ProvideInformation : BasePage
    {
        private static string qaEmail = "ozerep154+automated@gmail.com";

        public static IWebElement FirstName(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_FirstName"));
            return element;
        }
        public static IWebElement LastName(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_LastName"));
            return element;
        }
        public static IWebElement Address(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_Address"));
            return element;
        }
        public static IWebElement City(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_City"));
            return element;
        }
        public static IWebElement State(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ReservationState_dropdown"));
            return element;
        }
        public static IWebElement Zip(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_PostalCode"));
            return element;
        }
        public static IWebElement Phone(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_Phone"));
            return element;
        }
        public static IWebElement Email(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_Email"));
            return element;
        }
        public static IWebElement ReserveButton(IWebDriver driver)
        {
            //element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[2]/div/div[3]/div[2]/input")); //When payments don't exist
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[2]/div/div[5]/div[2]/input")); // When payments do exist
            return element;
        }
        public static IWebElement StartDate(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[1]/div[2]/span[2]"));
            return element;
        }
        public static IWebElement EndDate(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[1]/div[2]/span[3]"));
            return element;
        }
        //Added 09/29/2017 @ 8:39am 

        public static IWebElement CreditCardName(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_CreditCardName"));
            return element;
        }

        public static IWebElement CreditCardNumber(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_CreditCardNumber"));
            return element;
        }

        public static IWebElement CreditCardCVV(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_CreditCardCvv"));
            return element;
        }

        public static IWebElement CreditCardExpirationMonth(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ReservationCreditCardExpirationMonth_hidden"));
            return element;
        }

        public static IWebElement CreditCardExpirationYear(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ReservationCreditCardExpirationYear_hidden"));
            return element;
        }

        public static IWebElement CreditCardAddress(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_BillingAddress"));
            return element;
        }

        public static IWebElement CreditCardCity(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_BillingCity"));
            return element;
        }

        public static IWebElement CreditCardState(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ReservationBillingState_hidden"));
            return element;
        }

        public static IWebElement CreditCardZip(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_BillingPostalCode"));
            return element;
        }

        public static IWebElement OptCancelPolicy(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("Reservation_OptCancelPolicy"));
            return element;
        }

        public static void UserInfo(IWebDriver driver, Data.User user)
        {
            FirstName(driver).SendKeys(user.GetFirstName());
            LastName(driver).SendKeys(user.GetLastname());
            Address(driver).SendKeys(user.GetAddress());
            City(driver).SendKeys(user.GetCity() + Keys.Tab);
            State(driver).SendKeys(user.GetState());
            Zip(driver).SendKeys(user.GetZip());
            Phone(driver).SendKeys(user.GetPhone());
            Email(driver).SendKeys(qaEmail);
        }

        public static void PaymentInfo(IWebDriver driver, Data.User user)
        {
            // Element from Provide Info page
            CreditCardName(driver).Click();
            CreditCardName(driver).SendKeys(user.GetFirstName() + " " + user.GetLastname());

            CreditCardNumber(driver).Click();
            CreditCardNumber(driver).SendKeys("5454545454545454");

            CreditCardCVV(driver).Click();
            CreditCardCVV(driver).SendKeys("123");

            CreditCardExpirationMonth(driver).Click();
            CreditCardExpirationMonth(driver).SendKeys("5");

            CreditCardExpirationYear(driver).Click();
            CreditCardExpirationYear(driver).SendKeys("2018");

            CreditCardAddress(driver).Click();
            CreditCardAddress(driver).SendKeys(user.GetAddress());

            CreditCardCity(driver).Click();
            CreditCardCity(driver).SendKeys(user.GetCity());

            CreditCardState(driver).Click();
            CreditCardState(driver).SendKeys("F");

            CreditCardZip(driver).Click();
            CreditCardZip(driver).SendKeys(user.GetZip());

            OptCancelPolicy(driver).Click();   
        }

        public static void ClickReserve(IWebDriver driver)
        {
            ReserveButton(driver).Click();
        }
    }
}