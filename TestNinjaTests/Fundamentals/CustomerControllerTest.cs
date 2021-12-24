using TestNinja.Fundamentals;
using Xunit;

namespace TestNinjaTests.Fundamentals
{
    public class CustomerControllerTest
    {
        [Fact]
        public void GetCustomer_NotFoundTest()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            Assert.IsType<NotFound>(result);                // Is Of Type
            Assert.IsAssignableFrom<ActionResult>(result);  // Is Instance Of

        }
        
        [Fact]
        public void GetCustomer_OkTest()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(1);

            Assert.IsType<Ok>(result);                      // Is Of Type
            Assert.IsAssignableFrom<ActionResult>(result);  // Is Instance Of

        }
    }
}