using System.IO;

namespace Year2020.Day1
{
    public class Challenge
    {
        public static bool SumTo2020(int x, int y)
        {
            return x + y == 2020;
        }

        public static string[] GetInput()
        {
            var lines = File.ReadAllLines("Day1/Input.txt");
            return lines;
        }
    }
}