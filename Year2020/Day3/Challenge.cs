using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day3
{
    public static class Challenge
    {
        public static string[] GetInput()
        {
            return File.ReadAllLines("Day3/Input.txt");
        }

        public static int FindResult() // for part 1
        {
            return FindResult(new Way { Right = 3, Down = 1 });
        }

        public static int FindResult(Way way)
        {
            var lines = GetInput();
            var counter = 0;
            for (int i = 0; i < lines.Length; i += way.Down)
            {
                if (IsTree(i * way.Right, lines[i]))
                    counter++;
            }
            return counter;
        }

        public static bool IsTree(int idx, string line)
        {
            return line[idx % line.Length] == '#';
        }

        public static int FindAllResults(List<Way> ways)
        {
            return ways.Aggregate(1, (current, way) => current * FindResult(way));
        }

        public struct Way
        {
            public int Right { get; set; }
            public int Down { get; set; }
        }
    }
}