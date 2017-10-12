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

        [Test, Order(3)]
        public void LabelsOnFindAndReservePage()
        {
            Assert.AreEqual("Location", FindAndReserve.LocationLabel(driver).Text);
            Assert.AreEqual("Drop-off", FindAndReserve.StartDateLabel(driver).Text);
            Assert.AreEqual("Pick-up", FindAndReserve.EndDateLabel(driver).Text);
            Assert.AreEqual("Promo Code", FindAndReserve.DiscountLabel(driver).Text);

            validation.Add("Location Label", FindAndReserve.LocationLabel(driver).Text);
            validation.Add("Start Label", FindAndReserve.StartDateLabel(driver).Text);
            validation.Add("End Label", FindAndReserve.EndDateLabel(driver).Text);
            validation.Add("Discount Label", FindAndReserve.DiscountLabel(driver).Text);
        }

        [Test, Order(4)]
        public void ButtonsOnFindAndReservePage()
        {
            Assert.AreEqual("Continue As Member", FindAndReserve.ContinueAsMember(driver).GetAttribute("value").ToString());
            Assert.AreEqual("Continue As Guest", FindAndReserve.ContinueAsGuest(driver).GetAttribute("value").ToString());

            validation.Add("Member Button", FindAndReserve.ContinueAsMember(driver).GetAttribute("value").ToString());
            validation.Add("Guest Button", FindAndReserve.ContinueAsGuest(driver).GetAttribute("value").ToString());
        }
    }
}
