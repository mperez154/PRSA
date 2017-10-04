using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Pages;
using Automation.Interfaces;
using Automation.Data;
using NUnit.Framework;

namespace Automation.TestCases.Reservations
{
    [TestFixture]
    class FindAndReservePage : BaseTest
    {
        [Test, Order(1)]
        public void ChannelsOnFindAndReservePage()
        {
            //Coming from Channels data class
            Channels channels = new Channels();
            List<String> dbChannels = channels.GetAllChannels().ToList();

            //Coming from All Channels method in Find & Reserve Class
            FindAndReserve.OpenSite(driver, "QA", "WallyPark");
            List<string> UiChannels = new List<string>();
            UiChannels = FindAndReserve.AllChannels(driver);

            Assert.True(dbChannels.SequenceEqual(UiChannels));
            validation.Add("Default Channel", UiChannels[0]);
        }
        [Test, Order(2)]
        public void HeaderOnFindAndReservePage()
        {
            Assert.AreEqual("Find & Reserve", FindAndReserve.Header(driver).Text);
            validation.Add("Header Text", FindAndReserve.Header(driver).Text);
        }
    }
}
