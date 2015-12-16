using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using scaling_pancake;

namespace ScalingPancakeUnitTests
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public void CustomerObjectTestMethod()
        {
            Customer customer = new Customer("Albert", "yolo@mail.co.uk", "1234");
        }

        [TestMethod]
        public void CheckPasswordIsNull()
        {
            try
            {
                Customer albert = new Customer("Albert", "yolo@mail.co.uk", null);
                Assert.Fail();
                
            }
            catch (ArgumentNullException)
            {

            }
        }
        [TestMethod]
        public void CheckEmaiIsNull()
        {
            try
            {
                Customer hanne = new Customer("Hanne", null, "1234");

            }
            catch (ArgumentNullException)
            {

            }
        }
        

    

    }
}
