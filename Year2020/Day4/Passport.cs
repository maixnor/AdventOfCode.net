using System.Collections.Generic;

namespace Year2020.Day4
{
    public struct Passport
    {
        
        private int _byr;
        public string Byr
        {
            get => _byr.ToString();
            init => _byr = int.Parse(value);
        }

        private int _iyr;
        public string Iyr
        {
            get => _iyr.ToString();
            init => _iyr = int.Parse(value);
        }

        private int _eyr;
        public string Eyr
        {
            get => _eyr.ToString();
            init => _eyr = int.Parse(value);
        }

        private string _hgt;
        public string Hgt
        {
            get => _hgt;
            init => _hgt = value;
        }

        private string _hcl;
        public string Hcl
        {
            get => _hcl;
            init => _hcl = value;
        }

        private string _ecl;
        public string Ecl
        {
            get => _ecl;
            init => _ecl = value;
        }

        private string _pid;
        public string Pid
        {
            get => _pid;
            init => _pid = value;
        }

        private string _cid;
        public string Cid
        {
            get => _cid;
            init => _cid = value;
        }

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

        public bool IsFullyValid()
        {
            return IsValid() && Cid != null;
        }
        
    }
}