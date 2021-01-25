using System.Collections.Generic;
using System.IO;

namespace Year2020.Day7
{
    public class Challenge
    {
        public IEnumerable<Bag> GetBags(string[] data = null)
        {
            var bags = new List<Bag>();
            foreach (var line in data ?? GetData())
            {
                var parts = line.Split("bags contain"); // splits into bag and relations
                var containStrings = parts[1].Split(',');
                var contains = new Dictionary<Bag, int>();
                // get contain relations mapped
                foreach (var containing in containStrings)
                {
                    var relations = containing.Trim().Split(' ');
                    contains.Add(
                        new Bag { Color = $"{relations[1]} {relations[2]}" }, 
                        int.Parse(relations[0])
                    );
                }
                bags.Add(new Bag
                {
                    Color = parts[0].Trim(),
                    Contains = contains
                });
            }
            return bags;
        }
        
        public static IEnumerable<string> GetData()
        {
            return File.ReadAllLines("Day7/Input.txt");
        }
    }
}