using NUnit.Framework;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;
using System.Collections.Generic;
using System;

namespace Automation.TestCases
{
    class FindReserveTest : BaseTest
    {   
        [Test, Property("Priority", 1)]
        public void ValidateURL()
        {
            //Connect to DB and retrieve data. 
            List<Object> testUserData = new List<Object>();
            testUserData = DBConnect.GetUser();
            //Should pass
            //FindAndReserve.GetSite(driver, strngs.getReservationPage());
            //Assert.AreEqual("http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542", driver.Url);

            for (int i = 0; i < testUserData.Count; i++)
            {
                if(i % 4 == 0)
                {
                    Console.Write("\n");
                }
                Console.Write(testUserData[i] + "\n");
            }            
        }

        [Test, Property("Priority", 2)]
        public void ValidateTitle()
        {
            User user = new User();
            Console.Write(user.getFirstname());
            //Should Fail
            //FindAndReserve.GetSite(driver, strngs.getReservationPage());
            //Assert.AreEqual("WallyPark Reservation Fail", driver.Title);
        }
    }
}
