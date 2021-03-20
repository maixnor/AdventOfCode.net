using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Year2020.Day3;

namespace Test2020
{
    public class Day3
    {
        private string _testLine = "..##.......";
        private readonly ITestOutputHelper _testOutputHelper;

        public Day3(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Input()
        {
            Challenge.GetInput().Should().NotBeEmpty().And.Should().NotBeNull();
        }

        [Fact]
        public void IsTree()
        {
            Challenge.IsTree(0, _testLine).Should().BeTrue();
            Challenge.IsTree(2, _testLine).Should().BeFalse();
            // one "column" later (length of _testLine is 11)
            Challenge.IsTree(11, _testLine).Should().BeTrue();
            Challenge.IsTree(13, _testLine).Should().BeFalse();
        }

        [Fact]
        public void GetSolutionForResultOne()
        {
            _testOutputHelper.WriteLine(Challenge.FindResult().ToString());
        }

        [Fact]
        public void GetSolutionForResultTwo()
        {
            // go each way one and sum all the different ways
            var ways = new List<Challenge.Way>
            {
                new() {Right = 1, Down = 1},
                new() {Right = 3, Down = 1},
                new() {Right = 5, Down = 1},
                new() {Right = 7, Down = 1},
                new() {Right = 1, Down = 2}
            };
            _testOutputHelper.WriteLine(Challenge.FindAllResults(ways).ToString());
        }
    }
}