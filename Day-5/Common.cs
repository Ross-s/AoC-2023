using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Day5;
public static class Common
{
    public static (List<long> seeds, List<Map> maps) Parse(string input)
    {
        var firstLine = input.Split("\n")[0].Replace("seeds: ", "");

        // parse each number on the line
        var seeds = firstLine.Split(" ").Select(x => long.Parse(x)).ToList();

        Map? currentMap = null;
        List<Map> maps = new();

        foreach (var line in input.Split("\n")[2..])
        {
            if (string.IsNullOrEmpty(line)) continue;

            if (char.IsLetter(line[0]))
            {

                if (currentMap == null)
                {
                    currentMap = new Map();
                }
                else
                {
                    maps.Add(currentMap);
                    currentMap = new Map();
                }

                currentMap.SourceName = line.Split("-")[0];
                currentMap.DestinationName = line.Split("-")[2].Split(" ")[0];
            } else if (currentMap != null) {
                currentMap.Mappings.Add(new Mappings{
                    Destination = long.Parse(line.Split(" ")[0]),
                    Source = long.Parse(line.Split(" ")[1]),
                    Length = long.Parse(line.Split(" ")[2])
                });
            }
        }

        if (currentMap != null)
        {
            maps.Add(currentMap);
        }

        return (seeds, maps);
    }
}



public class Map
{
    public string? SourceName { get; set; }

    public string? DestinationName { get; set; }

    public List<Mappings> Mappings { get; set; } = new();
}

public class Mappings {
    public long Source { get; set; }

    public long Destination { get; set; }

    public long Length { get; set; }
}



