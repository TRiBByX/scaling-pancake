using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using scaling_pancake;

namespace ScalingPancakeUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CustomerObjectTestMethod()
        {
            Customer customer = new Customer("Albert", "yolo@mail.co.uk", "1234");
        }

        [TestMethod]
        public void InputCheckerTestMethod()
        {
            InputChecker.NullChecker("");
        }

        [TestMethod]
        public void Whatevertestmethod()
        {
            try
            {
                Customer albert = new Customer("", "", "");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail("some shit happened");
            }
        }

    }
}
