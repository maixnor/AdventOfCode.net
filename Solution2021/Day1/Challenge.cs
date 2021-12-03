using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution2021.Day1
{
    public class Challenge
    {
        public int First()
        {
            var numbers = File.ReadAllLines("Day1/input.txt").Select(int.Parse);
            return CountOfIncreasingDepth(numbers.ToArray());
        }

        public int Second()
        {
            var numbers = File.ReadAllLines("Day1/input.txt").Select(int.Parse);
            return CountOfIncreasingDepthWindow(numbers.ToArray());
        }
        
        public int CountOfIncreasingDepthWindow(int[] measurments)
        {
            var counter = 0;
            // start at second measurement (idx = 1)
            for (int i = 3; i < measurments.Length; i++)
            {
                var previousWindow = measurments[i - 3] + measurments[i - 2] + measurments[i - 1];
                var currentWindow = measurments[i - 2] + measurments[i - 1] + measurments[i];
                if (IsDeeperThanLast(previousWindow, currentWindow))
                {
                    counter++;
                }
            }

            return counter;
        }
        
        public int CountOfIncreasingDepth(int[] measurments)
        {
            var counter = 0;
            // start at second measurement (idx = 1)
            for (int i = 1; i < measurments.Length; i++)
            {
                if (IsDeeperThanLast(measurments[i - 1], measurments[i]))
                {
                    counter++;
                }
            }

            return counter;
        }
        
        public bool IsDeeperThanLast(int previous, int current)
        {
            return previous < current;
        }
    }
}