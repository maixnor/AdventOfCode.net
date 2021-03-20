using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Year2020.Day4;

namespace Test2020
{
    public class Day4
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Day4(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void FindValidCheckPassports()
        {
            // output is 161, the correct answer is 160, very weird
            // seems like the last is a duplicate (I just checked, it is not, very weird)
            // For part 1 I had the issue of the result being 1 too small, now this result is 1 too high
            // For part 1 the problem was that the last passport (valid) was not added in the en
            // I do not know now if the error lies in part 1 or 2
            _testOutputHelper.WriteLine(Challenge.FindValidCheckCount().ToString());
        }
        
        [Fact]
        public void FindValidPassports()
        {
            _testOutputHelper.WriteLine(Challenge.FindValidCount().ToString());
        }
        
        [Fact]
        public void Input()
        {
            Challenge.GetData().Should().NotBeEmpty().And.Should().NotBeNull();
        }

        [Fact]
        public void ParseAllPassports()
        {
            Challenge.ParseAllPassports().Length.Should().Be(282);
        }

        [Fact]
        public void Height_ParseHeightAndIsValid()
        {
            Height.ParseHeight("150cm").IsValid().Should().BeTrue();
            Height.ParseHeight("193cm").IsValid().Should().BeTrue();
            Height.ParseHeight("149cm").IsValid().Should().BeFalse();
            Height.ParseHeight("194cm").IsValid().Should().BeFalse();
            Height.ParseHeight("59in").IsValid().Should().BeTrue();
            Height.ParseHeight("76in").IsValid().Should().BeTrue();
            Height.ParseHeight("58in").IsValid().Should().BeFalse();
            Height.ParseHeight("77in").IsValid().Should().BeFalse();
        }

        [Fact]
        public void ParsedHeightToStringShouldBeHeight()
        {
            Height.ParseHeight("150cm").ToString().Should().Be("150cm");
            Height.ParseHeight("159cm").ToString().Should().NotBe("150cm");
            Height.ParseHeight("64in").ToString().Should().Be("64in");
            Height.ParseHeight("74in").ToString().Should().NotBe("64in");
        }

        [Fact]
        public void HairColorCheck()
        {
            Passport.HairColorCheck("#fffffd").Should().BeTrue();
            Passport.HairColorCheck("#fff4fd").Should().BeTrue();
            Passport.HairColorCheck("#fffff").Should().BeFalse();
            Passport.HairColorCheck("fffffd").Should().BeFalse();
            Passport.HairColorCheck("#fffgfd").Should().BeFalse();
        }

        [Fact]
        public void ParsePassport()
        {
            var expectedPassport = new Passport
            {
                Byr = "1937",
                Pid = "860033327",
                Eyr = "2020",
                Hcl = "#fffffd",
                Ecl = "gry",
                Iyr = "2017",
                Hgt = "183cm",
            };
            var actualPassport = Passport.ParsePassport(new[]
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });
            expectedPassport.Should().BeEquivalentTo(actualPassport);
        }
        
        [Fact]
        public void Passport_ValidCheck()
        {
            // let's check the valid first
            var passport = Passport.ParsePassport(new []
            {
                "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
                "hcl:#623a2f"
            });
            passport.IsValidCheck().Should().BeTrue();
            passport = Passport.ParsePassport(new []
            {
                "eyr:2029 ecl:blu cid:129 byr:1989",
                "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm"
            });
            passport.IsValidCheck().Should().BeTrue();
            passport = Passport.ParsePassport(new []
            {
                "hcl:#888785",
                "hgt:164cm byr:2001 iyr:2015 cid:88",
                "pid:545766238 ecl:hzl",
                "eyr:2022"
            });
            passport.IsValidCheck().Should().BeTrue();
            passport = Passport.ParsePassport(new []
            {
                "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719"
            });
            passport.IsValidCheck().Should().BeTrue();

            // now some invalid
            passport = Passport.ParsePassport(new []
            {
                "eyr:1972 cid:100",
                "hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926"
            });
            passport.IsValidCheck().Should().BeFalse();
            passport = Passport.ParsePassport(new []
            {
                "iyr:2019",
                "hcl:#602927 eyr:1967 hgt:170cm",
                "ecl:grn pid:012533040 byr:1946"
            });
            passport.IsValidCheck().Should().BeFalse();
            passport = Passport.ParsePassport(new []
            {
                "hcl:dab227 iyr:2012",
                "ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277"
            });
            passport.IsValidCheck().Should().BeFalse();
            passport = Passport.ParsePassport(new []
            {
                "hgt:59cm ecl:zzz",
                "eyr:2038 hcl:74454a iyr:2023",
                "pid:3556412378 byr:2007"
            });
            passport.IsValidCheck().Should().BeFalse();
        }

        [Fact]
        public void Passport_IsValid()
        {
            var passport = Passport.ParsePassport(new []
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });
            passport.IsValid().Should().BeTrue();
            passport = Passport.ParsePassport(new []
            {
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929"
            });
            passport.IsValid().Should().BeTrue();
            passport = Passport.ParsePassport(new []
            {
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm"
            });
            passport.IsValid().Should().BeTrue();
            passport = Passport.ParsePassport(new []
            {
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in"
            });
            passport.IsValid().Should().BeTrue();
        }
    }
}