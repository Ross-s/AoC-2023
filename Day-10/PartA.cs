using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day10
{

    public class PartA
    {
        private string input;

        public PartA(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(10).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            var map = Common.ParseMap(input);
            var result = Common.CalculateStepsToFarthestPoint(map); 

            stopwatch.Stop();
            var executionTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Execution time: {executionTime} ms");

            return result.ToString();
        }
    }
}