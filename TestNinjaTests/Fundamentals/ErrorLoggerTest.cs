using System;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinjaTests.Fundamentals
{
    public class ErrorLoggerTest
    {
        [Fact]
        public void Log_WhenCalled_UpdateProperty()
        {
            var logger = new ErrorLogger();

            Assert.Null(logger.LastError);

            logger.Log("msg");

            Assert.Equal("msg", logger.LastError);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Log_ExceptionTest(string error)
        {
            var logger = new ErrorLogger();

            Assert.Throws<ArgumentNullException>( () => logger.Log(error) );
        }

        [Fact]
        public void Log_WhenCalled_RaisesAnEvent()
        {
            var logger = new ErrorLogger();

            var guid = Guid.Empty;

            logger.ErrorLogged += (source, args) => 
            {
                guid = args;
            };

            logger.Log("msg");

            Assert.False(guid.CompareTo(Guid.Empty) == 0);
        }
    }
}