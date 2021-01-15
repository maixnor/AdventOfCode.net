using System.IO;

namespace Year2020.Day3
{
    public static class Challenge
    {
        public static string[] GetInput()
        {
            return File.ReadAllLines("Day3/Input.txt");
        }

        public static int FindResult()
        {
            var lines = GetInput();
            var counter = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (IsTree(i * 3, lines[i]))
                    counter++;
            }
            return counter;
        }

        public static bool IsTree(int idx, string line)
        {
            return line[idx % line.Length] == '#';
        }
    }
}