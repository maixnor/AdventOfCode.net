using System.IO;

namespace Year2020.Day4
{
    public class Challenge
    {
        public string[] GetData()
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

        public bool IsSemiValid()
        {
            return
                (Byr != null) &&
                (Iyr != null) &&
                (Eyr != null) &&
                (Hgt != null) &&
                (Hcl != null) &&
                (Ecl != null) &&
                (Pid != null);
        }

        public bool IsValid()
        {
            return IsSemiValid() && Cid != null;
        }
        
    }
    
}