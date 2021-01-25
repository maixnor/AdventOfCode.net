using Xunit;
using Xunit.Abstractions;
using Year2020.Day6;

namespace Test2020
{
    public class Day6
    {
        [Fact]
        public void FindCombinedAllCheckCount()
        {
            _testOutputHelper.WriteLine(Challenge.GetCombinedCountAll().ToString());
        }
        [Fact]
        public void FindCombinedAnyCheckCount()
        {
            _testOutputHelper.WriteLine(Challenge.GetCombinedCountAny().ToString());
        }

        [Fact]
        public void EnsureInput()
        {
            Assert.NotEmpty(Challenge.GetData());
        }

        [Fact]
        public void EnsureFormAll()
        {
            var form = new Form();
            Assert.Equal(0, form.AllCheckCount);
            form.AllCheck("abcx");
            Assert.Equal(4, form.AllCheckCount);
            form.AllCheck("abcy");
            Assert.Equal(3, form.AllCheckCount);
            form.AllCheck("abcz");
            Assert.Equal(3, form.AllCheckCount);
            form.AllCheck("1ASH");
            Assert.Equal(0, form.AllCheckCount);
        }

        [Fact]
        public void EnsureFormAny()
        {
            var form = new Form();
            Assert.Equal(0, form.AnyCheckCount);
            form.AnyCheck("abcx");
            Assert.Equal(4, form.AnyCheckCount);
            form.AnyCheck("abcy");
            Assert.Equal(5, form.AnyCheckCount);
            form.AnyCheck("abcz");
            Assert.Equal(6, form.AnyCheckCount);
            form.AnyCheck("1ASH");
            Assert.Equal(6, form.AnyCheckCount);
        }
        
        private readonly ITestOutputHelper _testOutputHelper;

        public Day6(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}