// using System;
using System.Linq;
using Xunit;
using TestNinja.Fundamentals;

namespace TestNinjaTests.Fundamentals
{
    public class MathTest
    {
        [Fact]
        public void AddTest()
        {
            var math = new Math();
            
            var result = math.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 2)]
        [InlineData(1, 1, 1)]
        public void MaxTest(int a, int b, int expected)
        {
            var math = new Math();
            
            var result = math.Max(a, b);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetOddNumbers_LimitIsPositive_ReturnsList()
        {
            var math = new Math();

            var odds = math.GetOddNumbers(5).ToList();

            Assert.Collection(odds, 
                i => Assert.Equal(1, i),
                i => Assert.Equal(3, i),
                i => Assert.Equal(5, i)
            );
        }
        
        [Fact]
        public void GetOddNumbers_LimitIsNegative_ReturnsEmptyList()
        {
            var math = new Math();

            var odds = math.GetOddNumbers(-5).ToList();

            Assert.Empty(odds);
            
            
        }
    }
}
