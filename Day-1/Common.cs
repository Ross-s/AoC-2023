using System.Text.RegularExpressions;

namespace Day1;
public static class Common
{
    public static string ParseAllNumbersFromString(string input, bool includeWords = false)
    {
        var numbers = string.Empty;

        var numberWords = new Dictionary<string, string> {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
        };

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (char.IsDigit(c))
            {
                numbers += c;
            }
            else if (includeWords && char.IsLetter(c))
            {
                var word = string.Empty;
                var foundWord = false;
                var tempI = i;
                while (char.IsLetter(c) && tempI < (input.Length - 1) && !foundWord)
                {
                    word += c;
                    tempI++;
                    c = input[tempI];

                    if (numberWords.ContainsKey(word))
                    {
                        numbers += numberWords[word];
                        foundWord = true;
                        i = i + word.Length - 1;
                    }
                }
            }
        }

        return numbers;
    }
}