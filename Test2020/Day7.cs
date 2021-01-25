using Xunit;
using Year2020.Day7;

namespace Test2020
{
    public class Day7
    {
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

        [Fact]
        public void EnsureGetBags()
        {
            // TODO for tomorrow
        }
    }
}