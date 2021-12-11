using System;
using Solution2021.Day2;
using Xunit;
using Xunit.Abstractions;

namespace Test2021
{
    public class Test2
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Test2(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void First()
        {
            _testOutputHelper.WriteLine(new Challenge().First().ToString());
        }
    }
}