using System.Collections.Generic;
using System.IO;

namespace Year2020.Day5
{
    public class Challenge
    {
        public static IEnumerable<string> GetData()
        {
            return File.ReadLines("Day5/Input.txt");
        }
    }
}