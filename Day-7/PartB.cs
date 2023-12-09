using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Day7
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(7).GetAwaiter().GetResult();
        }

        public string Solve()
        {
             var result = Common.Parse(input, true);
            
           
            return result;
        }
    }
}