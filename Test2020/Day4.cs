﻿using Xunit;
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
            var passport = Passport.ParsePassport(new []
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });
            Assert.True(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929"
            });
            Assert.False(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm"
            });
            Assert.True(passport.IsValidCheck());
            passport = Passport.ParsePassport(new []
            {
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in"
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