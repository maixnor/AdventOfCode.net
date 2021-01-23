using System;
using System.Linq;

namespace Year2020.Day5
{
    public struct Seat
    {
        private int RowUpperBound { get; set; }
        private int RowLowerBound { get; set; }
        private int ColUpperBound { get; set; }
        private int ColLowerBound { get; set; }

        private int RowDiff => RowUpperBound - RowLowerBound;
        private int ColDiff => ColUpperBound - ColLowerBound;
        
        public bool IsLimited => RowLowerBound == RowUpperBound && ColLowerBound == ColUpperBound;

        public Seat(string limiter)
        {
            RowUpperBound = Challenge.Rows - 1;
            ColUpperBound = Challenge.Cols - 1;
            RowLowerBound = 0;
            ColLowerBound = 0;
            Limit(limiter);
        }

        public Seat()
        {
            RowUpperBound = Challenge.Rows - 1;
            ColUpperBound = Challenge.Cols - 1;
            RowLowerBound = 0;
            ColLowerBound = 0;
        }

        public int SeatId => IsLimited ? -1 : RowUpperBound * Challenge.Cols + ColUpperBound;

        public bool Limit(string limiters)
        {
            return limiters.Any(Limit);
        }

        public bool Limit(char limiter)
        {
            switch (limiter)
            {
                // limit upper bound and lower bound of rows and cols using the limiter
                case RowUpperChar:
                    RowUpper();
                    break;
                case RowLowerChar:
                    RowLower();
                    break;
                case ColUpperChar:
                    ColUpper();
                    break;
                case ColLowerChar:
                    ColLower();
                    break;
            }
            return IsLimited;
        }

        private void RowUpper()
        {
            RowLowerBound += (int)Math.Pow(2, CurrentPowerRows);
            CurrentPowerRows--;
        }
        private void RowLower()
        {
            RowUpperBound -= RowDiff / 2;
        }
        private void ColUpper()
        {
            ColLowerBound += ColDiff / 2;
        }
        private void ColLower()
        {
            ColUpperBound -= ColDiff / 2;
        }
    }
}