using System;
using Xunit;
using Xunit.Abstractions;
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

        [Fact]
        public void EnsureResult()
        {
            var result = Challenge.GetResult();
            Assert.NotEqual(-1, result);
            _testOutputHelper.WriteLine(result.ToString());
        }
        
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

    }
}