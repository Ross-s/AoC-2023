using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day4
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(4).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var games = Common.PareseNumbers(input);

            var total = 0;

            foreach (var game in games)
            {
                var mathcing = new List<int>();

                game.MyNumbers?.ForEach(x =>
                {
                    if (game.WinningNumbers?.Contains(x) ?? false)
                    {
                        mathcing.Add(x);
                    }
                });

                if (mathcing.Count > 0)
                {
                    var baseMumber = 1;
                    for (var i = 0; i < mathcing.Count - 1; i++)
                    {
                        baseMumber *= 2;
                    }

                    total += baseMumber;
                }
            }

            return total.ToString();
        }
    }
}