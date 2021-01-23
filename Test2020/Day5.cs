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
            _testOutputHelper.WriteLine(Challenge.YourSeatID().ToString());
        }
        
        [Fact]
        public void EnsureLimitChar()
        {
            var seat = new Seat();
            Assert.False(seat.Limit("FBFBBFFRL"));
            Assert.True(seat.Limit('R'));
        }

        [Fact]
        public void EnsureLimitString()
        {
            Assert.True(new Seat().Limit("FBFBBFFRLR"));
            Assert.False(new Seat().Limit("FBBBBFRL")); // one too less
            Assert.False(new Seat().Limit("FBBBOFRLR")); // one different
            Assert.False(new Seat().Limit("FBBBFFFRLR")); // one too much
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