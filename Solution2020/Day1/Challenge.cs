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

        public static bool SumTo2020(int x, int y, int z)
        {
            return x + y + z== 2020;
        }

        public static int[] GetInput()
        {
            return File.ReadAllLines("Day1/Input.txt").Select(int.Parse).ToArray();
        }

        public static int GetResultForTwo()
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
        public static int GetResultForThree()
        {
            var numbers = GetInput();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for (int k = j + 1; k < numbers.Length - 2; k++)
                    {
                        if (SumTo2020(numbers[i], numbers[j], numbers[k]))
                        {
                            return numbers[i] * numbers[j] * numbers[k];
                        }
                    }
                }
            }
            return -1;
        }
    }
}