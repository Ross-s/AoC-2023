using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Day4;
public static class Common
{
    public static List<Game> PareseNumbers(string input)
    {
        List<Game> games = new List<Game>();
        foreach (var line in input.Trim().Split("\n"))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var gameId = Regex.Match(line, @"Card( |  |   )(?<gameId>\d+):").Groups["gameId"].Value;

            var game = new Game
            {
                Id = int.Parse(gameId),
            };

            var newString = Regex.Replace(line, @"Card( |  |   )\d+: ", "");

            game.WinningNumbers = newString.Split("|")[0].Trim().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x.Replace(" ", ""))!).ToList();
            game.MyNumbers = newString.Split("|")[1].Trim().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x.Replace(" ", ""))!).ToList();

            games.Add(game);
        }

        return games;
    }
}



public class Game
{
    public int Id { get; set; }
    public List<int>? WinningNumbers { get; set; }

    public List<int>? MyNumbers { get; set; }
}



