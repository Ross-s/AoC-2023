namespace Day3
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(3).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var lines = Common.ConvertToList(input);

            var result = Common.ParseIndividualLinesWithAgacent(lines, true);

            return result.ToString();
        }
    }
}