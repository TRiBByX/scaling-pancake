using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using scaling_pancake;

namespace ScalingPancakeUnitTests
{
    [TestClass]
   public class RentalTest
    {
        [TestMethod]
        public void RentalObjectTest()
        {
            Rental rental = new Rental
            {
                CustomerID = 1,
                EndDate = DateTime.Today.AddDays(1),
                StartDate = DateTime.Today
             };

            Assert.IsNotNull(rental);
        }
    }
}
