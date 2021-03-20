using Xunit;
using Xunit.Abstractions;
using Year2020.Day2;

namespace Test2020
{
    public class Day2
    {
        private string TestLine = "1-3 a: abcde";

        [Fact]
        public void FindValidCountRental()
        {
            _testOutputHelper.WriteLine(Challenge.FindValidCountRental().ToString());
        }

        [Fact]
        public void FindValidCountToboggan()
        {
            _testOutputHelper.WriteLine(Challenge.FindValidCountToboggan().ToString());
        }

        [Fact]
        public void From()
        {
            Assert.Equal(1, Challenge.GetFrom(TestLine));
        }
        
        [Fact]
        public void To()
        {
            Assert.Equal(3, Challenge.GetTo(TestLine));
        }

        [Fact]
        public void Character()
        {
            Assert.Equal('a', Challenge.GetCharacter(TestLine));
        }

        [Fact]
        public void Password()
        {
            Assert.Equal("abcde", Challenge.GetPassword(TestLine));
        }

        [Fact]
        public void Occurrences()
        {
            Assert.Equal(1,Challenge.Occurrences('a', Challenge.GetPassword(TestLine)));
        }

        [Fact]
        public void ValidRental()
        {
            Assert.True(Challenge.IsValidRental("1-3 a: abcde"));
            Assert.False(Challenge.IsValidRental("1-3 b: cdefg"));
            Assert.True(Challenge.IsValidRental("2-9 c: ccccccccc"));
        }
        
        [Fact]
        public void ValidToboggan()
        {
            Assert.True(Challenge.IsValidToboggan("1-3 a: abcde"));
            Assert.False(Challenge.IsValidToboggan("1-3 b: cdefg"));
            Assert.False(Challenge.IsValidToboggan("2-9 c: ccccccccc"));
        }
        
        [Fact]
        public void Input()
        {
            Assert.NotEmpty(Challenge.GetInput());            
        }
        
        private readonly ITestOutputHelper _testOutputHelper;
        public Day2(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}
