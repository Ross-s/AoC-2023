using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day5
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(5).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var data = Common.Parse(input);

            var lowest = long.MaxValue;

            foreach (var seed in data.seeds)
            {
                var currentMapping = seed;

                foreach (var currentMap in data.maps)
                {
                    var foundMapping = false;
                    foreach (var mapping in currentMap.Mappings)
                    {
                        if (!foundMapping)
                        {
                            var rangeStart = mapping.Source;
                            var rangeEnd = mapping.Source + mapping.Length;

                            if (currentMapping >= rangeStart && currentMapping <= rangeEnd)
                            {
                                if (currentMapping > rangeStart)
                                {
                                    currentMapping = mapping.Destination + (currentMapping - rangeStart);
                                }
                                else
                                {
                                    currentMapping = mapping.Destination;
                                }
                                foundMapping = true;
                            }
                        }
                    }
                }

                Console.WriteLine($"Seed {seed} maps to {currentMapping}");

                if (lowest > currentMapping)
                {
                    lowest = currentMapping;
                }
            }

            return lowest.ToString();
        }
    }
}