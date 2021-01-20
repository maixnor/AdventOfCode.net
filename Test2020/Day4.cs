using Xunit;
using Xunit.Abstractions;
using Year2020.Day4;

namespace Test2020
{
    public class Day4
    {
        [Fact]
        public void FindValidCheckPassports()
        {
            _testOutputHelper.WriteLine(Challenge.FindValidCheckCount().ToString());
        }
        
        [Fact]
        public void FindValidPassports()
        {
            _testOutputHelper.WriteLine(Challenge.FindValidCount().ToString());
        }
        
        [Fact]
        public void EnsureInput()
        {
            Assert.NotNull(Challenge.GetData());
        }

        [Fact]
        public void EnsureParseAllPassports()
        {
            var length = Challenge.ParseAllPassports().Length;
            Assert.Equal(282, length);
        }

        [Fact]
        public void EnsureHeightValidWithParse()
        {
            Assert.True(Height.ParseHeight("150cm").IsValid());
            Assert.True(Height.ParseHeight("193cm").IsValid());
            Assert.False(Height.ParseHeight("149cm").IsValid());
            Assert.False(Height.ParseHeight("194cm").IsValid());
            Assert.True(Height.ParseHeight("59in").IsValid());
            Assert.True(Height.ParseHeight("76in").IsValid());
            Assert.False(Height.ParseHeight("58in").IsValid());
            Assert.False(Height.ParseHeight("77in").IsValid());
        }

        [Fact]
        public void EnsureHeightToStringWithParse()
        {
            Assert.Equal("150cm", Height.ParseHeight("150cm").ToString());
            Assert.NotEqual("149cm", Height.ParseHeight("150cm").ToString());
            Assert.Equal("64in", Height.ParseHeight("64in").ToString());
            Assert.NotEqual("65in", Height.ParseHeight("64in").ToString());
        }

        [Fact]
        public void EnsureParsePassport()
        {
            var passport = new Passport
            {
                Byr = "1937",
                Pid = "860033327",
                Eyr = "2020",
                Hcl = "#fffffd",
                Ecl = "gry",
                Iyr = "2017",
                Hgt = "183cm",
            };
            var passportFromChallenge = Passport.ParsePassport(new[]
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });
            Assert.Equal(passport, passportFromChallenge);
        }
        
        [Fact]
        public void EnsurePassportValidCheck()
        {
            // let's check the valid first
            
            var passport = Passport.ParsePassport(new []
            {
                "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
                "hcl:#623a2f"
            });
            Assert.True(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "eyr:2029 ecl:blu cid:129 byr:1989",
                "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm"
            });
            Assert.True(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "hcl:#888785",
                "hgt:164cm byr:2001 iyr:2015 cid:88",
                "pid:545766238 ecl:hzl",
                "eyr:2022"
            });
            Assert.True(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719"
            });
            Assert.True(passport.IsValidCheck());

            // now some invalid
            
            passport = Passport.ParsePassport(new []
            {
                "eyr:1972 cid:100",
                "hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926"
            });
            Assert.False(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "iyr:2019",
                "hcl:#602927 eyr:1967 hgt:170cm",
                "ecl:grn pid:012533040 byr:1946"
            });
            Assert.False(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "hcl:dab227 iyr:2012",
                "ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277"
            });
            Assert.False(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "hgt:59cm ecl:zzz",
                "eyr:2038 hcl:74454a iyr:2023",
                "pid:3556412378 byr:2007"
            });
            Assert.False(passport.IsValidCheck());
        }

        [Fact]
        public void EnsurePassportValid()
        {
            var passport = Passport.ParsePassport(new []
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });
            Assert.True(passport.IsValid());
            passport = Passport.ParsePassport(new []
            {
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929"
            });
            Assert.False(passport.IsValid());
            passport = Passport.ParsePassport(new []
            {
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm"
            });
            Assert.True(passport.IsValid());
            passport = Passport.ParsePassport(new []
            {
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in"
            });
            Assert.False(passport.IsValid());
        }
        
        private readonly ITestOutputHelper _testOutputHelper;

        public Day4(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}