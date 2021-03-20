using System;
using System.Linq;
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
        public void Input()
        {
            Assert.NotEmpty(Challenge.GetData());
        }

        [Fact]
        public void GetFormsAll()
        {
            var data = new string[]
            {
                "adgvrhblps",
                "pghsdrbmalv",
                "hrlbpdasgv",
                "bgvsdplahr",
                string.Empty,
                "lgnpfhrm",
                "hwmng",
                "gunhmo"
            };
            var result = Challenge.GetFormsAll(data);
            _testOutputHelper.WriteLine(result.Sum(form => form.AllCheckCount).ToString());
        }

        [Fact]
        public void FormAll()
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
            form = new Form();
            form.AllCheck("adgvrhblps");
            Assert.Equal(10, form.AllCheckCount);
            form.AllCheck("pghsdrbmalv");
            Assert.Equal(10, form.AllCheckCount);
            form.AllCheck("hrlbpdasgv");
            Assert.Equal(10, form.AllCheckCount);
            form.AllCheck("bgvsdplahr");
            Assert.Equal(10, form.AllCheckCount);
            form = new Form();
            form.AllCheck("lgnpfhrm");
            Assert.Equal(8, form.AllCheckCount);
            form.AllCheck("hwmng");
            Assert.Equal(4, form.AllCheckCount);
            form.AllCheck("gunhmo");
            Assert.Equal(4, form.AllCheckCount);
        }

        [Fact]
        public void FormAny()
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