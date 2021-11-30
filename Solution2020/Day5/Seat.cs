
namespace Year2020.Day5
{
    public struct Seat
    {
        public int Row { get; init; }
        public int Col { get; init; }

        public int SeatId => Row * Challenge.Cols + Col;
        
    }
}