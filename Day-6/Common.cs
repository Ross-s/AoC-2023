using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day6;
public static class Common
{
    public static List<Race> Parse(string input, bool allNumbersAsOne = false)
    {
        var races = new List<Race>();
        List<long> timeNumbers = new();
        List<long> distanceNumbers = new();

        if (!allNumbersAsOne)
        {
            timeNumbers = Regex.Matches(input.Split("\n")[0], @"\d+")
                           .Select(m => long.Parse(m.Value))
                           .ToList();

            distanceNumbers = Regex.Matches(input.Split("\n")[1], @"\d+")
                               .Select(m => long.Parse(m.Value))
                               .ToList();
        }
        else
        {
            // Handle all numbers as one case
            timeNumbers = Regex.Matches(Regex.Replace(input.Split("\n")[1], "[^0-9]", ""), @"\d+")
                              .Select(m => long.Parse(m.Value))
                              .ToList();

            distanceNumbers = Regex.Matches(Regex.Replace(input.Split("\n")[1], "[^0-9]", ""), @"\d+")
                                  .Select(m => long.Parse(m.Value))
                                  .ToList();

        }

        for (int i = 0; i < timeNumbers.Count; i++)
        {
            var race = new Race
            {
                Time = timeNumbers[i],
                Distance = distanceNumbers[i]
            };

            races.Add(race);
        }

        return races;
    }

    public static int HowManyWaysCanIBeatRace(Race race)
    {
        var count = 0;
        Parallel.For(0, race.Time, new ParallelOptions {
            MaxDegreeOfParallelism = -1
        }, (i) =>
        {
            var holdButtonDown = i;
            var distance = race.Distance;
            var totalTime = race.Time;

            var distanceTravelled = (totalTime - holdButtonDown) * holdButtonDown;

            if (distanceTravelled > distance)
            {
                count++;
            }
        });

        return count;
    }
}



public class Race
{
    public long Distance { get; set; }

    public long Time { get; set; }
}


