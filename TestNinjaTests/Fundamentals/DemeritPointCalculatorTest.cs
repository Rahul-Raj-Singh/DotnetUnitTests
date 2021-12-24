using System;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinjaTests.Fundamentals
{
    public class DemeritPointCalculatorTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(301)]
        public void CalculateDemeritPoints_ArgsOutOfRange_ThrowException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.Throws<ArgumentOutOfRangeException> (
                () => { calculator.CalculateDemeritPoints(speed); }
            );
        }

        [Theory]
        [InlineData(20)]
        [InlineData(65)]
        public void CalculateDemeritPoints_SpeedWithinLimit_Return0(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(speed);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(70, 1)]
        [InlineData(73, 1)]
        [InlineData(75, 2)]
        public void CalculateDemeritPoints_SpeedOutsideLimit_ReturnDemeritPoint(int speed, int expectedDemeritPoint)
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(speed);
            
            Assert.Equal(expectedDemeritPoint, result);
        }
    }
}