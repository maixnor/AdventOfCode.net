using Xunit;
using Year2020.Day1;

namespace Test2020
{
    public class UnitTest1
    {
        [Fact]
        public void EnsureAddsUpTo2020()
        {
            Assert.True(Challenge.SumTo2020(1721, 299));
            Assert.False(Challenge.SumTo2020(1720, 299));
        }

        [Fact]
        public void EnsureInput()
        {
            Assert.NotEmpty(Challenge.GetInput());
        }
    }
}