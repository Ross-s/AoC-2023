using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Day5
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(5).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var data = Common.Parse(input);

            var lowest = long.MaxValue;

            for (var i = 0; i < data.seeds.Count / 2; i++)
            {
                var firstNumber = data.seeds[i * 2];
                var secondNumber = data.seeds[i * 2 + 1];

                // create a list of number between and including the two numbers
                var numbers = new List<long>();
                for (var j = firstNumber; j <= firstNumber + secondNumber; j++)
                {
                    numbers.Add(j);
                }

                var done = 0;

                Parallel.ForEach(numbers, new ParallelOptions {
                    MaxDegreeOfParallelism = -1
                }, (seed) =>
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

                    if (lowest > currentMapping)
                    {
                        lowest = currentMapping;
                    }

                    done++;
                    if (done % 100 == 0) {
                        Console.WriteLine($"Done {done} of {numbers.Count}");
                    }
                });
            }

            return lowest.ToString();
        }
    }
}