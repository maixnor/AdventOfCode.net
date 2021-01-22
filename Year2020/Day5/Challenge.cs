using System;
using System.Collections.Generic;
using System.IO;

namespace Year2020.Day5
{
    public class Challenge
    {
        private const int PowerRows = 7;
        private const int PowerCols = 3;
        private const char RowUpper = 'B';
        private const char RowLower = 'F';
        private const char ColUpper = 'R';
        private const char ColLower = 'L';

        public static int Rows => (int) Math.Pow(2, PowerRows);
        public static int Cols => (int) Math.Pow(2, PowerCols);

        public static IEnumerable<string> GetData()
        {
            return File.ReadLines("Day5/Input.txt");
        }
    }
}