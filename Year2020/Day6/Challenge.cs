using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Year2020.Day6
{
    public class Challenge
    {
        public static IEnumerable<string> GetData()
        {
            return File.ReadAllLines("Day6/Input.txt");
        }
    }
}