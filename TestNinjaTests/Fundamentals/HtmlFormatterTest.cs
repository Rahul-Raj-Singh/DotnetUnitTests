using TestNinja.Fundamentals;
using Xunit;

namespace TestNinjaTests.Fundamentals
{
    public class HtmlFormatterTest
    {
        [Fact]
        public void FormatAsBoldTest()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("hello");

            Assert.Contains("<strong>", result);
            Assert.Contains("</strong>", result);
            Assert.Equal("<strong>hello</strong>", result);
        }
    }
}