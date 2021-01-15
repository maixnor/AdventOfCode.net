using System;
using Xunit;
using Xunit.Abstractions;
using Year2020.Day3;

namespace Test2020
{
    public class Day3
    {
        private string TestLine = "..##.......";

        [Fact]
        public void EnsureInput()
        {
            Assert.NotEmpty(Challenge.GetInput());
        }

        [Fact]
        public void EnsureIsHit()
        {
            Assert.False(Challenge.IsTree(0, TestLine));
            Assert.True(Challenge.IsTree(2, TestLine));
            Assert.False(Challenge.IsTree(11, TestLine)); // + 11
            Assert.True(Challenge.IsTree(13, TestLine));  // + 11
        }

        [Fact]
        public void FindResult()
        {
            _testOutputHelper.WriteLine(Challenge.FindResult().ToString());
        }
        
        private readonly ITestOutputHelper _testOutputHelper;

        public Day3(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}