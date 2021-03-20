using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Year2020.Day2;

namespace Test2020
{
    public class Day2
    {
        private string _testLine = "1-3 a: abcde";
        private readonly ITestOutputHelper _testOutputHelper;
        public Day2(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetSolutionForValidCountRental()
        {
            _testOutputHelper.WriteLine(Challenge.FindValidCountRental().ToString());
        }

        [Fact]
        public void GetSolutionForValidCountToboggan()
        {
            _testOutputHelper.WriteLine(Challenge.FindValidCountToboggan().ToString());
        }

        [Fact]
        public void From()
        {
            Challenge.GetFrom(_testLine).Should().Be(1);
        }
        
        [Fact]
        public void To()
        {
            Challenge.GetTo(_testLine).Should().Be(3);
        }

        [Fact]
        public void Character()
        {
            Challenge.GetCharacter(_testLine).Should().Be('a');
        }

        [Fact]
        public void Password()
        {
            Challenge.GetPassword(_testLine).Should().Be("abcde");
        }

        [Fact]
        public void Occurrences()
        {
            Challenge.Occurrences('a', Challenge.GetPassword(_testLine)).Should().Be(1);
        }

        [Fact]
        public void ValidRental()
        {
            Challenge.IsValidRental("1-3 a: abcde").Should().BeTrue();
            Challenge.IsValidRental("1-3 b: cdefg").Should().BeFalse();
            Challenge.IsValidRental("2-9 c: ccccccccc").Should().BeTrue();
        }
        
        [Fact]
        public void ValidToboggan()
        {
            Challenge.IsValidToboggan("1-3 a: abcde").Should().BeTrue();
            Challenge.IsValidToboggan("1-3 b: cdefg").Should().BeFalse();
            Challenge.IsValidToboggan("2-9 c: ccccccccc").Should().BeFalse();
        }
        
        [Fact]
        public void Input()
        {
            Challenge.GetInput().Should().NotBeEmpty().And.Should().NotBeNull();
        }
    }
}
