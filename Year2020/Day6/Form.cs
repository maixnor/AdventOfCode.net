using System.Collections.Generic;

namespace Year2020.Day6
{
    public struct Form
    {
        private HashSet<char> Checks { get; }

        public int CheckCount => Checks.Count;

        public void Check(string checks)
        {
            foreach (var check in checks)
            {
                Checks.Add(check);
            }
        }
    }
}