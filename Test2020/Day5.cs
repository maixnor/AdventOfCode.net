using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Year2020.Day5;

namespace Test2020
{
    public class Day5
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Day5(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void FindHighestSeatNumber()
        {
            _testOutputHelper.WriteLine(Challenge.ParseAllSeats().Max(seat => seat.SeatId).ToString());
        }
        
        [Fact]
        public void FindYourSeatNumber()
        {
            _testOutputHelper.WriteLine(Challenge.YourSeatId().ToString());
        }

        [Fact]
        public void EnsureParseSeat()
        {
            Assert.Equal(357, Challenge.ParseSeat("FBFBBFFRLR").SeatId);
        }

        [Fact]
        public void EnsureGetRow()
        {
            Assert.Equal(44, Challenge.GetRow("FBFBBFF"));
            Assert.Equal(22, Challenge.GetRow("FBFBBF")); // one too less
            Assert.Equal(88, Challenge.GetRow("FBFBBFFF")); // one too much
            Assert.Equal(-1, Challenge.GetRow("FBFOBFF")); // one char off
        }

        [Fact]
        public void EnsureGetCol()
        {
            Assert.Equal(5, Challenge.GetCol("RLR"));
            Assert.Equal(2, Challenge.GetCol("RL"));
            Assert.Equal(11, Challenge.GetCol("RLRR"));
            Assert.Equal(-1, Challenge.GetCol("ROR"));
        }
        
        [Fact]
        public void EnsureParseAllSeats()
        {
            Assert.NotNull(Challenge.ParseAllSeats());
        }

        [Fact]
        public void EnsureGetData()
        {
            Assert.NotNull(Challenge.GetData());
        }
    }
}