using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    public static class Common
    {
        public static List<List<int>> ReadInput(string input)
        {
            var lines = input.Split("\n");
            var result = new List<List<int>>();
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var numbers = line.Split(" ").Select(int.Parse).ToList();
                    result.Add(numbers);
                }
            }
            return result;
        }

        public static int CalculateSumRight(List<List<int>> l)
        {
            return l.Sum(CalcRight);
        }

        private static int CalcRight(List<int> l)
        {
            if (l.Count(i => i != 0) == 0)
            {
                return 0;
            }
            var m = new List<int>();
            for (int i = 0; i < l.Count - 1; i++)
            {
                m.Add(l[i + 1] - l[i]);
            }
            return l.Last() + CalcRight(m);
        }

    }
}







