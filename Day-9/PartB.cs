using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day9
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(9).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            
             var numbers = Common.ReadInput(input);

            var result = Common.CalculateSumRight(numbers);

            return result.ToString();
        }
    }
}