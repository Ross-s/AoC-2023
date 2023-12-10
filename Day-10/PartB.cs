using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day10
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(10).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            
           return "Not Implemented Yet";
        }
    }
}