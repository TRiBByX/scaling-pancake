using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using scaling_pancake;

namespace ScalingPancakeUnitTests
{
    [TestClass]

    public class BookingTest
    {
        [TestMethod]
        public void BookingObjectTest()
        {
            Booking booking = new Booking(1);
        }

        [TestMethod]
        public void AddHomeTest01()
        {
            Booking booking = new Booking(1);
            booking.AddHome(new Home("Fasanvej 214", 2, 45));
        }

        [TestMethod]
        public void AddHomeTest02()
        {
            try
            {
                Booking booking = new Booking(1);
                booking.AddHome(new Home("Fasanvej 214", -2, 45));
                Assert.Fail();
            }
            catch(ArgumentOutOfRangeException)
            {

            }
        }
    }
}
