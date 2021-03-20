using System;
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
            var bagPart = parts[0];
            // parse bag with bag part
            var bag = ParseBag(bagPart);
            // split relation part by ',' => [2 posh black bags], [4 wavy gold bags], [2 vibrant brown bags.]
            // and parse to relations
            var relationsPart = parts[1];
            AddRelationsToBag(relationsPart, bag);
            return bag;
        }

        private static void AddRelationsToBag(string relationsPart, Bag bag)
        {
            foreach (var relationStr in relationsPart.Split(','))
            {
                AddRelationToBagIfNotEmpty(ParseRelation(relationStr), bag);
            }
        }

        private static void AddRelationToBagIfNotEmpty(KeyValuePair<Bag, int>? relation, Bag bag)
        {
            if (relation is not null)
                bag.Contains.Add(relation.Value.Key, relation.Value.Value);
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
            
            if (int.TryParse(split[0], out var number))
                return new KeyValuePair<Bag, int>(
                    ParseBag(split[1]),
                    number
                );

            throw new Exception("This is not a valid relation string: "+str);
        }
        
        public static IEnumerable<string> GetData()
        {
            return File.ReadAllLines("Day7/Input.txt");
        }
    }
}