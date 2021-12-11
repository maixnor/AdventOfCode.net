using System.IO;
using System.Linq;

namespace Solution2021.Day2
{
    public class Challenge
    {
        public int Depth { get; set; }
        public int Position { get; set; }

        public int First()
        {
            var instructions = File.ReadAllLines("Day2/input.txt");
            foreach (var instruction in instructions)
            {
                Move(instruction);
            }
            return Depth * Position;
        }

        public void Move(string instruction)
        {
            var direction = instruction.Split(" ")[0];
            var magnitude = int.Parse(instruction.Split(" ")[1]);

            switch (direction)
            {
                case "forward":
                    Position += magnitude;
                    break;
                case "down":
                    Depth += magnitude;
                    break;
                case "up":
                    Depth -= magnitude;
                    break;
            }
        }
        
    }
}