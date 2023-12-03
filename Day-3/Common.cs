using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Day3;
public static class Common
{
    public static List<string> ConvertToList(string input)
    {
        var list = new List<string>();
        foreach (var line in input.Split("\n"))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            list.Add(line);
        }

        return list;
    }

    public static int ParseIndividualLinesWithAgacent(List<string> lines, bool onlyAstrix = false)
    {

        var splitLines = new List<List<char>>();

        foreach (var line in lines)
        {
            var newLine = new List<char>();
            foreach (var character in line)
            {
                newLine.Add(character);
            }

            splitLines.Add(newLine);
        }

        var totalNumbers = 0;

        for (int i = 0; i < splitLines.Count; i++)
        {
            for (int j = 0; j < splitLines[i].Count; j++)
            {
                var numbers = new List<string>();

                if (!char.IsNumber(splitLines[i][j]) && ((splitLines[i][j] != '.' && !onlyAstrix) || (splitLines[i][j] == '*' && onlyAstrix)))
                {
                    // is there a number directly to the right of left?
                    if (j > 0)
                    {
                        var result = CheckLineAndPosition(splitLines, i, j - 1);

                        if (result.number != null)
                        {
                            numbers.Add(result.number);
                            splitLines = result.lines;
                        }
                    }

                    if (j < splitLines[i].Count - 1)
                    {
                        var result = CheckLineAndPosition(splitLines, i, j + 1);

                        if (result.number != null)
                        {
                            numbers.Add(result.number);
                            splitLines = result.lines;
                        }
                    }

                    // check line directly above
                    if (i > 0)
                    {
                        var result = CheckLineAndPosition(splitLines, i - 1, j);

                        if (result.number != null)
                        {
                            numbers.Add(result.number);
                            splitLines = result.lines;
                        }
                    }

                    // check line directly below
                    if (i < splitLines.Count - 1)
                    {
                        var result = CheckLineAndPosition(splitLines, i + 1, j);

                        if (result.number != null)
                        {
                            numbers.Add(result.number);
                            splitLines = result.lines;
                        }
                    }

                    // check lines directly above one to left
                    if (i > 0 && j > 0)
                    {
                        var result = CheckLineAndPosition(splitLines, i - 1, j - 1);

                        if (result.number != null)
                        {
                            numbers.Add(result.number);
                            splitLines = result.lines;
                        }
                    }

                    // check lines directly above one to right
                    if (i > 0 && j < splitLines[i].Count - 1)
                    {
                        var result = CheckLineAndPosition(splitLines, i - 1, j + 1);

                        if (result.number != null)
                        {
                            numbers.Add(result.number);
                            splitLines = result.lines;
                        }
                    }

                    // check lines directly below one to left
                    if (i < splitLines.Count - 1 && j > 0)
                    {
                        var result = CheckLineAndPosition(splitLines, i + 1, j - 1);

                        if (result.number != null)
                        {
                            numbers.Add(result.number);
                            splitLines = result.lines;
                        }
                    }

                    // check lines directly below one to right
                    if (i < splitLines.Count - 1 && j < splitLines[i].Count - 1)
                    {
                        var result = CheckLineAndPosition(splitLines, i + 1, j + 1);
                        if (result.number != null)
                        {
                            numbers.Add(result.number);
                            splitLines = result.lines;
                        }
                    }
                }

                if (numbers.Count > 0 && !onlyAstrix)
                {
                    totalNumbers += numbers.Select(x => int.Parse(x)).Sum();
                }

                if (numbers.Count > 1 && onlyAstrix)
                {
                    var nums = numbers.Select(x => int.Parse(x)).ToList();
                    totalNumbers += nums[0] * nums[1];
                }
            }
        }
        return totalNumbers;

    }

    static (string? number, List<List<char>> lines) CheckLineAndPosition(List<List<char>> splitLines, int i, int j)
    {
        if (char.IsNumber(splitLines[i][j]))
        {
            var result = GetValueAtRecursive(splitLines[i], j);

            splitLines[i][j] = '.';
            for (int k = 0; k < result.RemoveFromLeft; k++)
            {
                splitLines[i][j - k - 1] = '.';
            }

            for (int k = 0; k < result.RemoveFromRight; k++)
            {
                splitLines[i][j + k + 1] = '.';
            }

            return (result.number, splitLines);
        }

        return (null, splitLines);
    }

    static (int RemoveFromLeft, int RemoveFromRight, string number) GetValueAtRecursive(List<char> line, int index)
    {
        var numbersToLeft = new List<char>();
        if (index != 0 && char.IsNumber(line[index - 1]))
        {
            var tempIndex = index - 1;
            while (tempIndex >= 0 && char.IsNumber(line[tempIndex]))
            {
                numbersToLeft.Add(line[tempIndex]);
                tempIndex--;
            }
        }

        var numbersToRight = new List<char>();
        if (index != line.Count - 1 && char.IsNumber(line[index + 1]))
        {
            var tempIndex = index + 1;
            while (tempIndex < line.Count && char.IsNumber(line[tempIndex]))
            {
                numbersToRight.Add(line[tempIndex]);
                tempIndex++;
            }
        }

        numbersToLeft.Reverse();

        var numbers = $"{string.Join("", numbersToLeft)}{line[index]}{string.Join("", numbersToRight)}";

        return (numbersToLeft.Count, numbersToRight.Count, numbers);
    }
}



