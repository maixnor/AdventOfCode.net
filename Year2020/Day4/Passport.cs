using System.Collections.Generic;

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

        public bool IsValidCheck()
        {
            return false;
        }

    }
}