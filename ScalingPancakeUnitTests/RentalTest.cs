using System;
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
            Rental rental = new Rental(1, DateTime.Today.AddDays(1), DateTime.Today.AddDays(2));
        }
    }
}
