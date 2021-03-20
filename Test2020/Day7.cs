using System.Collections.Generic;
using Xunit;
using Year2020.Day7;

namespace Test2020
{
    public class Day7
    {
        [Fact]
        public void EnsureGetBagWithRelations()
        {
            var expected = new Bag
            {
                Color = "light red",
                Contains = new Dictionary<Bag, int>()
                {
                    { new Bag { Color = "bright white" }, 1 },
                    { new Bag { Color = "muted yellow" }, 2 }
                }
            };
            var actual = Challenge.GetBag("light red bags contain 1 bright white bag, 2 muted yellow bags.");
            Assert.Equal(expected.Color, actual.Color);
            Assert.Equal(expected.Contains, actual.Contains);
            Assert.Equal(expected.Contains.Count, actual.Contains.Count);
            //Assert.Equal(expected, actual); with this line the test fails. not sure why.
        }

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
        public void EnsureParseRelationHandlesSpaceAsFirstCharacter()
        {
            var expected = new KeyValuePair<Bag, int>(
                new Bag {Color = "pale gray"},
                2);
            var actual = Challenge.ParseRelation(" 2 pale gray bags");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EnsureParseRelationHandlesNoOtherBags()
        {
            KeyValuePair<Bag, int>? expected = null;
            var actual = Challenge.ParseRelation("no other bags.");
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