using System;
using System.Linq;

namespace Year2020.Day5
{
    public struct Seat
    {
        public int Row { get; init; }
        public int Col { get; init; }

        public bool IsValid => Row >= 0 && Col >= 0;

        public int SeatId => IsValid ? Row * Challenge.Cols + Col : -1;
        
    }
}