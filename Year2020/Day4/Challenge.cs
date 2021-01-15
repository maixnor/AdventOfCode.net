using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day4
{
    public class Challenge
    {

        public static int FindSemiValidCount()
        {
            return ParseAllPassports().Count(passport => passport.IsValid());
        }

        public static Passport[] ParseAllPassports()
        {
            return ParseAllPassports(GetData());
        }

        public static Passport[] ParseAllPassports(string[] data)
        {
            var passports = new List<Passport>();
            var lines = new List<string>();
            foreach (var line in data)
            {
                if (line == string.Empty)
                {
                    passports.Add(ParsePassport(lines.ToArray()));
                    lines = new List<string>();
                }
                else
                {
                    lines.Add(line);
                }
            }
            return passports.ToArray();
        }

        public static Passport ParsePassport(string[] lines)
        {
            var fields = new List<string>();
            foreach (var line in lines)
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

        public static string[] GetData()
        {
            return File.ReadAllLines("Day4/Input.txt");
        }
    }

    public struct Passport
    {
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }
        public string Cid { get; set; }

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