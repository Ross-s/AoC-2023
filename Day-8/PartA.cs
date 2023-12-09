using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day8
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(8).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var parsed = Common.Parse(input);

            var currentMap = "AAA";

            var directionIndex = 0;
            var mapCount = 0;

            while (currentMap != "ZZZ") 
            {
                var map = parsed.maps.FirstOrDefault(x => x.Id == currentMap);

                if (map == null)
                {
                    return "No map found";
                }

                if (parsed.direction[directionIndex] == 'R')
                {
                    currentMap = map.Right;
                } else {
                    currentMap = map.Left;
                }

                directionIndex++;

                if (directionIndex == parsed.direction.Length)
                {
                    directionIndex = 0;
                }

                mapCount++;
            }

            return mapCount.ToString();
        }
    }
}