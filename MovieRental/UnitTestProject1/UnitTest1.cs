using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRental.Controllers;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CustomersUnitTest()
        {   //Arrange
            CustomersUnitTestController controller = new CustomersUnitTestController();
            //Act
            IActionResult result = controller.Index() as IActionResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DirectorsUnitTest()
        {   //Arrange
            DirectorsUnitTestController controller = new DirectorsUnitTestController();
            //Act
            IActionResult result = controller.Index() as IActionResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MoviesUnitTest()
        {   //Arrange
            MoviesUnitTestController controller = new MoviesUnitTestController();
            //Act
            IActionResult result = controller.Index() as IActionResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
