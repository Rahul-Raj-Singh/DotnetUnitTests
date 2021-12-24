using TestNinja.Fundamentals;
using Xunit;

namespace TestNinjaTests.Fundamentals
{
    public class FizzBuzzTest
    {
        [Theory]
        [InlineData(15, "FizzBuzz")]
        [InlineData(6, "Fizz")]
        [InlineData(10, "Buzz")]
        [InlineData(4, "4")]
        public void GetOutputTest(int number, string expected)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.Equal(expected, result);
        }
    }
}