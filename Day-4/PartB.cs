using System.Runtime.CompilerServices;

namespace Day4
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(4).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var games = Common.PareseNumbers(input);

            var instanceCounts = new List<int>();
            var yIndex = 1;

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

                if (instanceCounts.Count < yIndex)
                {
                    instanceCounts.Add(1);
                }
                else
                {
                    instanceCounts[yIndex - 1]++;
                }

                if (mathcing.Count > 0)
                {
                    var currentCardCopies = instanceCounts[yIndex - 1];
                    foreach (var cardNumber in Enumerable.Range(yIndex + 1, mathcing.Count))
                    {
                        if (instanceCounts.Count < cardNumber)
                        {
                            instanceCounts.Add(currentCardCopies);
                        }
                        else
                        {
                            instanceCounts[cardNumber - 1] += currentCardCopies;
                        }
                    }
                }

                yIndex++;
            }


            return instanceCounts.Sum().ToString();
        }




    }

}