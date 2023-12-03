namespace Day3
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(3).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var lines = Common.ConvertToList(input);

            var result = Common.ParseIndividualLinesWithAgacent(lines);

            return result.ToString();
        }
    }
}