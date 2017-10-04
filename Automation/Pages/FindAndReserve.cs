using OpenQA.Selenium;
using Automation.Interfaces;
using System;
using Automation.Data;
using System.Drawing;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.ObjectModel;

namespace Automation.Pages
{
    class FindAndReserve : BasePage
    {
        public static IWebElement Location(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRates"));
            return element;
        }
        public static void ClickLocation(IWebDriver driver)
        {
            Location(driver).Click();
        }

        public static IWebElement LocationDropdown(IWebDriver driver)
        {
            //element = driver.FindElement(By.XPath(".//*[@id='ShopRates']/div[1]/ul/li[3]"));
            element = driver.FindElement(By.XPath(".//*[@id='ShopRates']/div/ul/li[2]"));
            return element;
        }

        public static string CompanyID(IWebDriver driver)
        {
            //Company ID (used to determine site (wally park, joes, etc)
            return driver.FindElement(By.XPath("//*[@id='UniqueId']")).GetAttribute("value").ToString();
        }

        public static List<string> AllChannels(IWebDriver driver)
        {
            List<IWebElement> elements = new List<IWebElement>();
            List<string> channels = new List<string>();
            elements = driver.FindElements(By.ClassName("e-ddltxt")).ToList();
            foreach (IWebElement option in elements)
            {
                channels.Add(option.GetAttribute("innerHTML"));
            }
            return channels;
        }

        public static IWebElement StartDate(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRatesStartDate"));
            return element;
        }

        public static IWebElement EndDate(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRatesEndDate"));
            return element;
        }

        public static IWebElement Discount(IWebDriver driver)
        {
            element = driver.FindElement(By.Id("ShopRates_DiscountPromo"));
            return element;
        }

        public static IWebElement LocationLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[1]/div[1]/span/label"));
            return element;
        }

        public static IWebElement StartDateLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[2]/div[1]/span/label"));
            return element;
        }

        public static IWebElement EndDateLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[3]/div[1]/span/label"));
            return element;
        }

        public static IWebElement DiscountLabel(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[4]/div[1]/span/label"));
            return element;
        }

        public static IWebElement ContinueAsMember(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[5]/div[1]/input"));
            return element;
        }

        public static IWebElement ContinueAsGuest(IWebDriver driver)
        {
            element = driver.FindElement(By.XPath(".//*[@id='form0']/div/div[5]/div[2]/input"));
            return element;
        }

        public static IWebElement Header(IWebDriver driver)
        {
            element = driver.FindElement(By.TagName("h1"));

            return element;
        }

        public static void StartReservation(IWebDriver driver, DateTime date)
        {
            ClickLocation(driver);   //Test to see if line above can be replaced
            LocationDropdown(driver).SendKeys(Keys.Down + Keys.Down);
            StartDate(driver).Clear();
            StartDate(driver).SendKeys(date.ToString(Strngs.GetDateFormat()) + Keys.Tab);
            EndDate(driver).Clear();
            EndDate(driver).SendKeys(date.Add(TimeSpan.FromDays(GetRandomNumber(1, 5))).ToString(Strngs.GetDateFormat()));
            Discount(driver).Click();
            ContinueAsGuest(driver).Click(); //Click continue as guest
        }

        public static void OpenSite(IWebDriver driver, string environment, string site)
        {
            GetSite(driver, GetReservationURL(environment, site));
            driver.Manage().Window.Size = new Size(1600, 1050);
        }

        public static int GetRandomNumber(int start, int end)
        {
            Random random = new Random();
            int myNumber = random.Next(start, end);
            return myNumber;
        }

    }
}