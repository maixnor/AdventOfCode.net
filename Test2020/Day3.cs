using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Year2020.Day3;

namespace Test2020
{
    public class Day3
    {
        private string TestLine = "..##.......";

        [Fact]
        public void Input()
        {
            Assert.NotEmpty(Challenge.GetInput());
        }

        [Fact]
        public void IsHit()
        {
            Assert.False(Challenge.IsTree(0, TestLine));
            Assert.True(Challenge.IsTree(2, TestLine));
            Assert.False(Challenge.IsTree(11, TestLine)); // + 11
            Assert.True(Challenge.IsTree(13, TestLine));  // + 11
        }

        [Fact]
        public void FindResultOne()
        {
            _testOutputHelper.WriteLine(Challenge.FindResult().ToString());
        }

        [Fact]
        public void FindAllResults()
        {
            var values = new List<Challenge.Way>
            {
                new() {Right = 1, Down = 1},
                new() {Right = 3, Down = 1},
                new() {Right = 5, Down = 1},
                new() {Right = 7, Down = 1},
                new() {Right = 1, Down = 2}
            };
            _testOutputHelper.WriteLine(Challenge.FindAllResults(values).ToString());
        }
        
        private readonly ITestOutputHelper _testOutputHelper;

        public Day3(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}