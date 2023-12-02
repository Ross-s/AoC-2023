namespace Day1
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(1).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var input = this.input;

            var allNumbers = new List<int>();

            foreach (var line in input.Split("\n"))
            {
                var numbers = Common.ParseAllNumbersFromString(line);
                if (numbers.Length == 0) continue;

                // get the first number
                var firstNumber = numbers[0];

                // get the last number
                var lastNumber = numbers[numbers.Length - 1];

                var number = int.Parse(firstNumber.ToString() + lastNumber.ToString());

                allNumbers.Add(number);
            }

            return allNumbers.Sum().ToString();
        }
    }
}