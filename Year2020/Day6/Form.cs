using System.Collections.Generic;

namespace Year2020.Day6
{
    public struct Form
    {
        public SortedSet<char> Checks { get; }

        public int ChecksCount()
        {
            return Checks.Count;
        }

        public void Check(string checks)
        {
            foreach (var check in checks)
            {
                Check(check);
            }
        }

        public void Check(char check)
        {
            Checks.Add(check);
        }
    }
}