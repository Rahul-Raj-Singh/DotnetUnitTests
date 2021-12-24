using System;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinjaTests.Fundamentals
{
    public class StackTest
    {
        [Fact]
        public void Push_WhenNullPushed_ThrowException()
        {
            var stack = new Stack<string>();

            Assert.Throws<ArgumentNullException>( () => stack.Push(null) );
        }

        [Fact]
        public void PushTest()
        {
            var stack = new Stack<string>();

            stack.Push("a");

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_WhenStackEmpty_ThrowException()
        {
            var stack = new Stack<string>();

            Assert.Throws<InvalidOperationException>( () => stack.Pop() );
        }

        [Fact]
        public void PopTest()
        {
            var stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");

            var result = stack.Pop();

            Assert.Equal("b", result);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Peek_WhenStackEmpty_ThrowException()
        {
            var stack = new Stack<string>();

            Assert.Throws<InvalidOperationException>( () => stack.Peek() );
        }

        [Fact]
        public void PeekTest()
        {
            var stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");

            var result = stack.Peek();

            Assert.Equal("b", result);
            Assert.Equal(2, stack.Count);
        }
    }
}