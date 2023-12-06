using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Day6
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(6).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var races = Common.Parse(input, true);

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