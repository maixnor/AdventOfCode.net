using System.Linq;
using FluentAssertions;
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
        public void ParseSeat()
        {
            Challenge.ParseSeat("FBFBBFFRLR").SeatId.Should().Be(357);
        }

        [Fact]
        public void GetRow()
        {
            Challenge.GetRow("FBFBBFF").Should().Be(44);
            Challenge.GetRow("FBFBBF").Should().Be(22); // one too less
            Challenge.GetRow("FBFBBFFF").Should().Be(88); // one too much
            Challenge.GetRow("FBFOBFF").Should().Be(-1); // one char off
        }

        [Fact]
        public void GetCol()
        {
            Challenge.GetCol("RLR").Should().Be(5);
            Challenge.GetCol("RL").Should().Be(2); // one too less
            Challenge.GetCol("RLRR").Should().Be(11); // one too much
            Challenge.GetCol("ROR").Should().Be(-1); // one char off
        }
        
        [Fact]
        public void ParseAllSeats()
        {
            Challenge.ParseAllSeats().Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetData()
        {
            Challenge.GetData().Should().NotBeNullOrEmpty();
        }
    }
}