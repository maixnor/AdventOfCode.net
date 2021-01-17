using Xunit;
using Xunit.Abstractions;
using Year2020.Day4;

namespace Test2020
{
    public class Day4
    {
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
            Assert.Equal(282, Challenge.ParseAllPassports().Length);
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
                Cid = "147"
            };
            var passportFromChallenge = Passport.ParsePassport(new[]
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });
            Assert.Equal(passport, passportFromChallenge);
        }

        [Fact]
        public void EnsurePassportFullyValid()
        {
            var passport = Passport.ParsePassport(new []
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });
            Assert.True(passport.IsFullyValid());
            passport = Passport.ParsePassport(new []
            {
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929"
            });
            Assert.False(passport.IsFullyValid());
            passport = Passport.ParsePassport(new []
            {
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm"
            });
            Assert.False(passport.IsFullyValid());
            passport = Passport.ParsePassport(new []
            {
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in"
            });
            Assert.False(passport.IsFullyValid());
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