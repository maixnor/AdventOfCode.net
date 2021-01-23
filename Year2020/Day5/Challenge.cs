using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day5
{
    public class Challenge
    {
        private const char RowUpperChar = 'B';
        private const char RowLowerChar = 'F';
        private const char ColUpperChar = 'R';
        private const char ColLowerChar = 'L';

        private const int PowerRows = 7;
        private const int PowerCols = 3;
        
        public static int Rows => (int) Math.Pow(2, PowerRows);
        public static int Cols => (int) Math.Pow(2, PowerCols);

        public static int YourSeatId()
        {
            var seats = ParseAllSeats().OrderBy(seat => seat.SeatId).ToArray();
            // cycle from the 2nd to the 2nd to last seat (could not be first or last)
            // and I do not have to check for OutOfBounds each cycle
            for (int i = 1; i < seats.Length - 1; i++)
            {
                if (seats[i - 1].SeatId + 1 == seats[i].SeatId && seats[i].SeatId == seats[i + 1].SeatId - 1)
                    return seats[i].SeatId;
            }
            return -1;
        }

        public static IEnumerable<Seat> ParseAllSeats()
        {
            return GetData().Select(ParseSeat);
        }

        public static Seat ParseSeat(string defintion)
        {
            return new()
            {
                Row = GetRow(defintion.Substring(0, PowerRows)),
                Col = GetCol(defintion.Substring(PowerCols - 1))
            };
        }

        public static int GetRow(string definition, int lower = 0)
        {
            if (definition == string.Empty)
                return lower;
            if (definition.StartsWith(RowLowerChar))
                return GetRow(definition.Substring(1), lower);
            if (definition.StartsWith(RowUpperChar))
                return GetRow(definition.Substring(1), lower + (int) Math.Pow(2, definition.Length - 1));
            return -1;
        }
        public static int GetCol(string definition, int lower = 0)
        {
            if (definition == string.Empty)
                return lower;
            if (definition.StartsWith(ColLowerChar))
                return GetCol(definition.Substring(1), lower);
            if (definition.StartsWith(ColUpperChar))
                return GetCol(definition.Substring(1), lower + (int) Math.Pow(2, definition.Length - 1));
            return -1;
        }
        
        public static IEnumerable<string> GetData()
        {
            return File.ReadLines("Day5/Input.txt");
        }
    }
}