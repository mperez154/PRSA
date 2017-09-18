using OpenQA.Selenium;
using Automation.Interfaces;

namespace Automation.Pages
{
    class ProvideInformation : BasePage
    {
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
    }
}
