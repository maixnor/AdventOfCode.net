using System.Collections.Generic;
using System.Linq;

namespace Year2020.Day6
{
    public class Form
    {
        public Form()
        {
            AnyChecks = new HashSet<char>();
        }
        
        private List<char> AllChecks { get; set; }
        private HashSet<char> AnyChecks { get; }

        public int CheckCount => AnyChecks.Count;

        public void AllCheck(string checks)
        {
            if (AllChecks == null)
                AllChecks = new List<char>(checks);
            else
            {
                foreach (var check in checks.Where(check => 97 <= check && check <= 122))
                {
                    if (!AllChecks.Contains(check))
                        AllChecks.Remove(check);
                }
            }
        }

        public void AnyCheck(string checks)
        {
            foreach (var check in checks.Where(check => 97 <= check && check <= 122))
            {
                AnyChecks.Add(check);
            }
        }
    }
}