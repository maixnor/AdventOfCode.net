using System.Collections.Generic;
using System.Linq;

namespace Year2020.Day4
{
    public struct Passport
    {
        public static Passport ParsePassport(IEnumerable<string> data)
        {
            var fields = new List<string>();
            foreach (var line in data)
            {
                fields.AddRange(line.Split(" "));
            }
            var passport = new Passport();
            foreach (var field in fields)
            {
                var split = field.Split(":");
                var key = split[0];
                var value = split[1];
                switch (key)
                {
                    case "ecl":
                        passport.Ecl = value;
                        break;
                    case "pid":
                        passport.Pid = value;
                        break;
                    case "eyr":
                        passport.Eyr = value;
                        break;
                    case "hcl":
                        passport.Hcl = value;
                        break;
                    case "byr":
                        passport.Byr = value;
                        break;
                    case "iyr":
                        passport.Iyr = value;
                        break;
                    case "hgt":
                        passport.Hgt = value;
                        break;
                }
            }
            return passport;
        }
        
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }

        public bool IsValid()
        {
            return
                Byr != null &&
                Iyr != null &&
                Eyr != null &&
                Hgt != null &&
                Hcl != null &&
                Ecl != null &&
                Pid != null;
        }

        private static readonly string[] EyeColors = {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
        public bool IsValidCheck()
        {
            return IsValid() &&
                   int.TryParse(Byr, out var byr) && 1920 <= byr && byr <= 2002 &&
                   int.TryParse(Iyr, out var iyr) && 2010 <= iyr && iyr <= 2030 &&
                   int.TryParse(Eyr, out var eyr) && 2020 <= eyr && eyr <= 2030 &&
                   Height.ParseHeight(Hgt).IsValid() &&
                   Hcl.Length == 7 && Hcl.StartsWith('#') && //uint.TryParse(Hcl.Substring(1), out _) &&
                   EyeColors.Contains(Ecl) &&
                   Pid.Length == 9 && int.TryParse(Pid, out _);
        }

    }
}