namespace Day2
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
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
                var maxRed = game.Rounds?.Max(x => x.Red) ?? 0;
                var maxGreen = game.Rounds?.Max(x => x.Green) ?? 0;
                var maxBlue = game.Rounds?.Max(x => x.Blue) ?? 0;

                var power = maxRed * maxGreen * maxBlue;

                countOfValidGames += power;
            }

            return countOfValidGames.ToString();
        }
    }
}