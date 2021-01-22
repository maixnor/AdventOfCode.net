using System;
using System.Collections.Generic;
using System.IO;

namespace Year2020.Day5
{
    public class Challenge
    {
        private static readonly int PowerRows = 7; 
        private static readonly int PowerCols = 3;

        public static IEnumerable<string> GetData()
        {
            return File.ReadLines("Day5/Input.txt");
        }
    }
}