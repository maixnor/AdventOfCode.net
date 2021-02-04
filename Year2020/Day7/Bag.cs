using System.Collections.Generic;

namespace Year2020.Day7
{
    public struct Bag
    {
        public string Color { get; init; }
        public Dictionary<Bag, int> Contains { get; set; }

        public bool IsOfColor(string color)
        {
            return color == Color;
        }
    }
}