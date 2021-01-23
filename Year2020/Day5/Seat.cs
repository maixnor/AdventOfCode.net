using System;
using System.Linq;

namespace Year2020.Day5
{
    public struct Seat
    {
        public static int Row { get; set; }
        public static int Col { get; set; }

        public static int SeatId => Row * Challenge.Cols + Col;
        
    }
}