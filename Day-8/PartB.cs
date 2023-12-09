using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day8
{

    public class PartB
    {
        private string input;

        public PartB(string Secret, DailyInput input)
        {
            this.input = input.GetInputForDay(8).GetAwaiter().GetResult();
        }

        public string Solve()
        {
            var parsed = Common.Parse(input);

            var startingNodes = parsed.maps.Where(x => x.Id.EndsWith("A")).ToList();
            var currentNodes = new List<Map>(startingNodes);

            var steps = 0;
            var currentDirectionIndex = 0;

            while (currentNodes.Any(x => !x.Id.EndsWith("Z")))
            {
                var nextNodes = new List<Map>();

                foreach (var node in currentNodes)
                {
                    if (parsed.direction[currentDirectionIndex] == 'L')
                    {
                        var leftNode = parsed.maps.First(x => x.Id == node.Left);
                        nextNodes.Add(leftNode);
                    }
                    else
                    {
                        var rightNode = parsed.maps.First(x => x.Id == node.Right);
                        nextNodes.Add(rightNode);
                    }
                }

                currentDirectionIndex++;

                if (currentDirectionIndex == parsed.direction.Length)
                {
                    currentDirectionIndex = 0;
                }

                currentNodes = nextNodes;
                steps++;
            }

            return steps.ToString();
        }
    }
}