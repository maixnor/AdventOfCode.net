using System.Collections.Generic;
using System.Linq;

namespace Year2020.Day6
{
    public struct Form
    {
        private HashSet<char> AllChecks { get; set; }
        private HashSet<char> AnyChecks { get; set; }

        public int AllCheckCount => AllChecks?.Count ?? 0;
        public int AnyCheckCount => AnyChecks?.Count ?? 0;

        public void AllCheck(string checks)
        {
            AllChecks ??= new HashSet<char>(checks);
            
            var checksArr = checks.Where(check => 97 <= check && check <= 122).ToHashSet();
            foreach (var check in AllChecks)
            {
                if (!checksArr.Contains(check))
                    AllChecks.Remove(check);
            }
        }

        public void AnyCheck(string checks)
        {
            AnyChecks ??= new HashSet<char>(checks);
            
            foreach (var check in checks.Where(check => 97 <= check && check <= 122))
            {
                AnyChecks.Add(check);
            }
        }
    }
}