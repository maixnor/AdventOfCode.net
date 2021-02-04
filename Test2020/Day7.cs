using System.Collections.Generic;
using Xunit;
using Year2020.Day7;

namespace Test2020
{
    public class Day7
    {

        [Fact]
        public void EnsureParseBag()
        {
            var expected = new Bag {Color = "pale gray"};
            var actual = Challenge.ParseBag("pale gray bag");
            Assert.Equal(expected, actual);
            var actualPlural = Challenge.ParseBag("pale gray bags");
            Assert.Equal(expected, actualPlural);
        }

        [Fact]
        public void EnsureParseRelation()
        {
            var expected = new KeyValuePair<Bag, int>(
                new Bag {Color = "pale gray"},
                2);
            var actual = Challenge.ParseRelation("2 pale gray bags");
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void EnsureData()
        {
            Assert.NotNull(Challenge.GetData());
        }

        [Fact]
        public void EnsureBagIsOfColor()
        {
            Assert.True(new Bag {Color = "light red"}.IsOfColor("light red"));
            Assert.True(new Bag {Color = "dark orange"}.IsOfColor("dark orange"));
            Assert.True(new Bag {Color = "bright white"}.IsOfColor("bright white"));
        }

    }
}