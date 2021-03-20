using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day7
{
    public class Challenge
    {
        public IEnumerable<Bag> GetBags(string[] data = null)
        {
            var bags = new List<Bag>();
            foreach (var line in data ?? GetData())
            {
                bags.Add(GetBag(line));                
            }
            return bags;
        }

        public static Bag GetBag(string line)
        {
            // [pale cyan bags contain 2 posh black bags, 4 wavy gold bags, 2 vibrant brown bags.]
            // split by "contain" => [pale cyan bags], [2 posh black bags, 4 wavy gold bags, 2 vibrant brown bags.]
            var parts = line.Split("contain");
            // parse bag with bag part
            var bag = ParseBag(parts[0]);
            // split relation part by ',' => [2 posh black bags], [4 wavy gold bags], [2 vibrant brown bags.]
            // and parse to relations
            foreach (var part in parts[1].Split(','))
            {
                var relation = ParseRelation(part);
                if (relation is not null)
                    bag.Contains.Add(relation.Value.Key, relation.Value.Value);
            }
            return bag;
        }

        public static Bag ParseBag(string str)
        {
            // [pale cyan bags]
            // split by ' ' => [pale], [cyan], ([bags])
            var split = str.Split(' ');
            return new Bag {Color = $"{split[0]} {split[1]}"};
        }

        public static KeyValuePair<Bag, int>? ParseRelation(string str)
        {
            // [2 posh black bags]
            // if str contains "no other bags return null
            if (str.Contains("no other bags"))
                return null;
            // split by ' ' once => [2], [posh black bags]
            var split = str.Trim().Split(' ', 2);
            return new KeyValuePair<Bag, int>(
                ParseBag(split[1]),
                int.Parse(split[0])
            );
        }
        
        public static IEnumerable<string> GetData()
        {
            return File.ReadAllLines("Day7/Input.txt");
        }
    }
}