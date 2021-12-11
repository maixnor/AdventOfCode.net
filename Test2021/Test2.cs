using System;
using Solution2021.Day2;
using Xunit;
using Xunit.Abstractions;

namespace Test2021
{
    public class Test2
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Challenge _challenge;

        public Test2(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _challenge = new Challenge();
        }

        [Fact]
        public void First()
        {
            _testOutputHelper.WriteLine(_challenge.First().ToString());
        }

        [Fact]
        public void Second()
        {
            _testOutputHelper.WriteLine(_challenge.Second().ToString());
        }
    }
}