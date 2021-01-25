using System.Collections.Generic;

namespace Year2020.Day6
{
    public class Form
    {
        public Form()
        {
            Checks = new HashSet<char>();
        }
        private HashSet<char> Checks { get; }

        public int CheckCount => Checks.Count;

        public void Check(string checks)
        {
            foreach (var check in checks)
            {
                if (97 <= check && check <= 122) // check if char is a lowercase character
                    Checks.Add(check);
            }
        }
    }
}