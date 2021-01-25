using System.Collections.Generic;

namespace Year2020.Day6
{
    public class Form
    {
        public Form()
        {
            AnyChecks = new HashSet<char>();
        }
        
        private HashSet<char> AnyChecks { get; }

        public int CheckCount => AnyChecks.Count;

        public void AnyCheck(string checks)
        {
            foreach (var check in checks)
            {
                if (97 <= check && check <= 122) // check if char is a lowercase character
                    AnyChecks.Add(check);
            }
        }
    }
}