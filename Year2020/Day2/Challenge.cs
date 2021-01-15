using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day2
{
    public static class Challenge
    {

        public static string[] GetInput()
        {
            var lines = File.ReadAllLines("Day2/Input.txt");
            return lines;
        }

        public static int GetFrom(string line)
        {
            return int.Parse(line.Substring(0, line.IndexOf('-')));
        }

        public static int GetTo(string line)
        {
            var startIndex = line.IndexOf('-');
            return int.Parse(line.Substring(startIndex + 1, line.IndexOf(' ') - startIndex));
        }

        public static char GetCharacter(string line)
        {
            return line[line.IndexOf(':') - 1];
        }

        public static string GetPassword(string line)
        {
            return line.Substring(line.IndexOf(':') + 2);
        }

        public static int Occurrences(char character, string password)
        {
            return password.Count(letter => character == letter);
        }

        public static bool IsValid(string line)
        {
            var occurrences = Occurrences(GetCharacter(line), GetPassword(line));
            return GetFrom(line) <= occurrences && occurrences <= GetTo(line);
        }
    }
}