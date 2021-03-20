using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Year2020.Day1;

namespace Test2020
{
    public class Day1
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        public Day1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void AddsUpTo2020_ForTwoAndForThreeNumbers()
        {
            Challenge.SumTo2020(1721, 299).Should().BeTrue();
            Challenge.SumTo2020(1720, 299).Should().BeFalse();
            
            Challenge.SumTo2020(979, 366, 675).Should().BeTrue();
            Challenge.SumTo2020(978, 366, 675).Should().BeTrue();
        }

        [Fact]
        public void Input_NotEmpty()
        {
            Challenge.GetInput().Should().NotBeEmpty().And.Should().NotBeNull();
        }

        [Fact]
        public void ResultForTwo_HasSolution()
        {
            Challenge.GetResultForTwo().Should().NotBe(-1);
        }

        [Fact]
        public void GetSolutionForTwoNumbers()
        {
            _testOutputHelper.WriteLine(Challenge.GetResultForTwo().ToString());
        }
        
        [Fact]
        public void ResultForThree_HasSolution()
        {
            Challenge.GetResultForThree().Should().NotBe(-1);
        }

        [Fact]
        public void GetSolutionForThreeNumbers()
        {
            _testOutputHelper.WriteLine(Challenge.GetResultForThree().ToString());
        }
    }
}