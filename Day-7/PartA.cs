using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day7
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(7).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var result = Common.Parse(input);
            
           
            return result;
        }
    }
}