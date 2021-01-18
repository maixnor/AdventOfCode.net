using System.Collections.Generic;

namespace Year2020.Day4
{
    public struct Passport
    {

        #region fields

        private int _byr;
        public string Byr
        {
            get => _byr.ToString();
            set => _byr = int.Parse(value);
        }

        private int _iyr;
        public string Iyr
        {
            get => _iyr.ToString();
            set => _iyr = int.Parse(value);
        }

        private int _eyr;
        public string Eyr
        {
            get => _eyr.ToString();
            set => _eyr = int.Parse(value);
        }

        private Height _hgt;
        public string Hgt
        {
            get => _hgt.ToString();
            set => _hgt = Height.ParseHeight(value);
        }

        private string _hcl;
        public string Hcl
        {
            get => _hcl;
            set => _hcl = value;
        }

        private static List<string> colors = new()
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };

        private string _ecl;
        public string Ecl
        {
            get => _ecl;
            set => _ecl = value;
        }

        private int _pid;
        public string Pid
        {
            get => _pid.ToString();
            set => _pid = int.Parse(value);
        }

        private string _cid;
        public string Cid
        {
            get => _cid;
            set => _cid = value;
        }

        #endregion
        
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
                    case "cid":
                        passport.Cid = value;
                        break;
                    case "hgt":
                        passport.Hgt = value;
                        break;
                }
            }
            return passport;
        }

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
            return
                Byr != null && 1920 <= _byr && _byr <= 2002 &&
                Iyr != null && 2010 <= _iyr && _iyr <= 2020 &&
                Eyr != null && 2020 <= _eyr && _eyr <= 2030 &&
                Hgt != null && _hgt.IsValid() &&
                Hcl != null && uint.TryParse(_hcl, out var hcl) &&
                Ecl != null && colors.Contains(_ecl) && 
                Pid.Length == 9 && 0 > _pid && _pid >= 999999999;
        }
    }
}