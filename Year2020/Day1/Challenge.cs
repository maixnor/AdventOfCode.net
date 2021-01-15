using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace Year2020.Day1
{
    public static class Challenge
    {
        public static bool SumTo2020(int x, int y)
        {
            return x + y == 2020;
        }

        public static int[] GetInput()
        {
            var lines = File.ReadAllLines("Day1/Input.txt");
            return lines.Select(int.Parse).ToArray();
        }

        public static int GetResult()
        {
            var numbers = GetInput();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (SumTo2020(numbers[i], numbers[j]))
                    {
                        return numbers[i] * numbers[j];
                    }
                }
            }
            return -1;
        }
    }
}