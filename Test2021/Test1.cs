using System;
using FluentAssertions;
using Solution2021.Day1;
using Xunit;
using Xunit.Abstractions;

namespace Test2021
{
    public class Tests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private Challenge challenge;

        public Tests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            challenge = new Challenge();
        }

        [Fact]
        public void First()
        {
            _testOutputHelper.WriteLine(challenge.First().ToString());
        }

        [Fact]
        public void Second()
        {
            _testOutputHelper.WriteLine(challenge.Second().ToString());
        }

        [Fact]
        public void CountOfIncreasingDepthWindow()
        {
            var ints = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            challenge.CountOfIncreasingDepthWindow(ints).Should().Be(5);
        }
        
        [Fact]
        public void CountOfIncreasingDepth()
        {
            var ints = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            challenge.CountOfIncreasingDepth(ints).Should().Be(7);
        }
        
        [InlineData(199, 200, true)]
        [InlineData(200, 208, true)]
        [InlineData(210, 200, false)]
        [Theory]
        public void IsDeeperThanLast(int previous, int current, bool expected)
        {
            challenge.IsDeeperThanLast(previous, current).Should().Be(expected);
        }
    }
}