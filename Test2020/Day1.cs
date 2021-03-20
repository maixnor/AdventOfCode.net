using Xunit;
using Xunit.Abstractions;
using Year2020.Day1;

namespace Test2020
{
    public class Day1
    {
        [Fact]
        public void AddsUpTo2020()
        {
            Assert.True(Challenge.SumTo2020(1721, 299));
            Assert.False(Challenge.SumTo2020(1720, 299));
            Assert.True(Challenge.SumTo2020(979, 366, 675));
            Assert.False(Challenge.SumTo2020(977, 366, 675));
        }

        [Fact]
        public void Input()
        {
            Assert.NotEmpty(Challenge.GetInput());
        }

        [Fact]
        public void ResultForTwo()
        {
            var result = Challenge.GetResultForTwo();
            Assert.NotEqual(-1, result);
            _testOutputHelper.WriteLine(result.ToString());
        }
        
        [Fact]
        public void ResultForThree()
        {
            var result = Challenge.GetResultForThree();
            Assert.NotEqual(-1, result);
            _testOutputHelper.WriteLine(result.ToString());
        }
        
        private readonly ITestOutputHelper _testOutputHelper;

        public Day1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

    }
}