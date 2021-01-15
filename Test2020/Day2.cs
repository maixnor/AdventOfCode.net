using Xunit;
using Year2020.Day2;

namespace Test2020
{
    public class Day2
    {

        private string TestLine = "1-3 a: abcde";

        [Fact]
        public void EnsureFrom()
        {
            Assert.Equal(1, Challenge.GetFrom(TestLine));
        }
        
        [Fact]
        public void EnsureTo()
        {
            Assert.Equal(3, Challenge.GetTo(TestLine));
        }

        [Fact]
        public void EnsureCharacter()
        {
            Assert.Equal('a', Challenge.GetCharacter(TestLine));
        }

        [Fact]
        public void EnsurePassword()
        {
            Assert.Equal("abcde", Challenge.GetPassword(TestLine));
        }

        [Fact]
        public void EnsureOccurrences()
        {
            Assert.Equal(1,Challenge.Occurrences('a', Challenge.GetPassword(TestLine)));
        }

        [Fact]
        public void EnsureValid()
        {
            Assert.True(Challenge.IsValid("1-3 a: abcde"));
            Assert.False(Challenge.IsValid("1-3 b: cdefg"));
            Assert.True(Challenge.IsValid("2-9 c: ccccccccc"));
        }
        
        [Fact]
        public void EnsureInput()
        {
            Assert.NotEmpty(Challenge.GetInput());            
        }
    }
}