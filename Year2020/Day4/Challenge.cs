using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day4
{
    public static class Challenge
    {
        public static int FindValidCheckCount()
        {
            var passports = ParseAllPassports();
            return passports.Count(passport => passport.IsValidCheck());
        }

        public static int FindValidCount()
        {
            var passports = ParseAllPassports();
            return passports.Count(passport => passport.IsValid());
        }

        public static Passport[] ParseAllPassports()
        {
            return ParseAllPassports(GetData());
        }

        public static Passport[] ParseAllPassports(IEnumerable<string> data)
        {
            var passports = new List<Passport>();
            var lines = new List<string>();
            foreach (var line in data)
            {
                if (line == string.Empty)
                {
                    // last line must be empty for the last passport to be read
                    passports.Add(Passport.ParsePassport(lines.ToArray())); 
                    lines = new List<string>();
                }
                else
                {
                    lines.Add(line);
                }
            }
            passports.Add(Passport.ParsePassport(lines.ToArray()));
            return passports.ToArray();
        }

        public static string[] GetData()
        {
            return File.ReadAllLines("Day4/Input.txt");
        }
    }

}