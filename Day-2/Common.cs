using System.Text.RegularExpressions;

namespace Day2;
public static class Common
{
    public static List<Game> ParseGames(string input)
    {
        var games = new List<Game>();
        foreach (var line in input.Split("\n"))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var gameId = Regex.Match(line, @"Game (?<gameId>\d+):").Groups["gameId"].Value;

            var game = new Game
            {
                Id = int.Parse(gameId),
            };

            var newString = Regex.Replace(line, @"Game \d+: ", "");

            var rounds = new List<Round>();

            foreach (var round in newString.Split(";"))
            {
                var red = Regex.Match(round, @"(?<red>\d+) red").Groups["red"].Value;
                var green = Regex.Match(round, @"(?<green>\d+) green").Groups["green"].Value;
                var blue = Regex.Match(round, @"(?<blue>\d+) blue").Groups["blue"].Value;

                if (string.IsNullOrWhiteSpace(red))
                {
                    red = "0";
                }

                if (string.IsNullOrWhiteSpace(green))
                {
                    green = "0";
                }

                if (string.IsNullOrWhiteSpace(blue))
                {
                    blue = "0";
                }

                var newRound = new Round
                {
                    Red = int.Parse(red),
                    Green = int.Parse(green),
                    Blue = int.Parse(blue),
                };

                rounds.Add(newRound);
            }

            game.Rounds = rounds;

            games.Add(game);

        }

        return games;
    }
}



public class Game
{
    public int Id { get; set; }

    public List<Round>? Rounds { get; set; }
}

public class Round
{
    public int Red { get; set; }
    public int Green { get; set; }

    public int Blue { get; set; }
}