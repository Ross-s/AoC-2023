using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day6
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(6).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var races = Common.Parse(input);

            var count = 0;

            foreach (var race in races) {
                var result = Common.HowManyWaysCanIBeatRace(race);

                if (count == 0)
                {
                    count = result;
                } else {
                    count *= result;
                }
            }

            return count.ToString();
        }
    }
}