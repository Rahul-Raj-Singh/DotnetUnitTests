using System.Net;
using TestNinja.Mocking;
using TestNinja.Mocking.Refactored;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestNinjaTests.Mocking
{
    public class EmployeeControllerTest
    {
        [Fact]
        public void DeleteEmployeeTest()
        {
            var repo = new Mock<IEmployeeRepository>();
            var controller = new EmployeeController(repo.Object);

            var result = controller.DeleteEmployee(1);

            repo.Verify(r => r.Delete(1), Times.Once);
            Assert.IsType<RedirectResult>(result);
            Assert.IsAssignableFrom<ActionResult>(result);

        }
        
    }
}