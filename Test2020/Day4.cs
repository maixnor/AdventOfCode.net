using System;
using Xunit;
using Xunit.Abstractions;
using Year2020.Day4;

namespace Test2020
{
    public class Day4
    {
        [Fact]
        public void FindSemiValidPassports()
        {
            _testOutputHelper.WriteLine(Challenge.FindSemiValidCount().ToString());
        }
        
        [Fact]
        public void EnsureInput()
        {
            Assert.NotNull(Challenge.GetData());
        }

        [Fact]
        public void EnsureParseAllPassports()
        {
            Assert.Equal(281, Challenge.ParseAllPassports().Length);
        }

        [Fact]
        public void EnsureParsePassport()
        {
            var passport = new Passport
            {
                Byr = "gry",
                Pid = "860033327",
                Eyr = "2020",
                Hcl = "#fffffd",
                Ecl = "1937",
                Iyr = "2017",
                Hgt = "183cm",
                Cid = "147"
            };
            var passportFromChallenge = Challenge.ParsePassport(new[]
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });
            Assert.Equal(passport, passportFromChallenge);
        }

        [Fact]
        public void EnsurePassportValid()
        {
            var passport = new Passport
            {
                Byr = "gry",
                Pid = "860033327",
                Eyr = "2020",
                Hcl = "#fffffd",
                Ecl = "1937",
                Iyr = "2017",
                Hgt = "183cm"
            };
            Assert.False(passport.IsFullyValid());
            passport.Cid = "147";
            Assert.True(passport.IsFullyValid());
        }

        [Fact]
        public void EnsurePassportSemiValid()
        {
            var passport = new Passport
            {
                Byr = "gry",
                Pid = "860033327",
                Eyr = "2020",
                Hcl = "#fffffd",
                Ecl = "1937",
                Iyr = "2017",
                Hgt = "183cm"
            };
            Assert.True(passport.IsValid());
        }
        
        private readonly ITestOutputHelper _testOutputHelper;

        public Day4(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}