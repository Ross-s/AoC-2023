namespace Day2
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(2).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var input = this.input;

            var games = Common.ParseGames(input);

            var countOfValidGames = 0;

            foreach (var game in games)
            {
                // is red valid 
                if (game.Rounds != null && game.Rounds.All(x => x.Red <= 12 && x.Blue <= 14 && x.Green <= 13))
                {
                    countOfValidGames += game.Id;
                }
            }

            return countOfValidGames.ToString();
        }
    }
}