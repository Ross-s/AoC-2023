using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8;
public static class Common
{
    public static (List<Map> maps, string direction) Parse(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var maps = new List<Map>(); 
        var direction = string.Empty;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            if (i == 0)
            {
                direction = line;
                continue;
            } else {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var map = new Map();
                var split = line.Split(" = ");
                map.Id = split[0];

                map.Left = split[1].Split(",")[0].Replace("(", "");
                map.Right = split[1].Split(",")[1].Replace(")", "").Replace(" ", "");

                maps.Add(map);
            }
        }

        return (maps, direction);
    } 
}


public class Map {
    public string Id { get; set; }

    public string Left { get; set; }

    public string Right { get; set; }
}




