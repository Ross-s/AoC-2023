using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7;
public static class Common
{


    private static Dictionary<char, int> scores = new Dictionary<char, int>
        {
            {'A', 13},
            {'K', 12},
            {'Q', 11},
            {'J', 10},
            {'T', 9},
            {'9', 8},
            {'8', 7},
            {'7', 6},
            {'6', 5},
            {'5', 4},
            {'4', 3},
            {'3', 2},
            {'2', 1}
        };

    private static int part = 1;

    private static int GetType(List<char> h)
    {
        var c = h.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        if (part == 2 && h.Contains('J'))
        {
            var jCount = c['J'];
            c.Remove('J');
            if (c.Count == 0)
            {
                c['A'] = 5;
            }
            else
            {
                var mc = c.OrderByDescending(x => x.Value).First().Key;
                c[mc] += jCount;
            }
        }

        var sortedValues = c.Values.OrderBy(x => x).ToList();

        if (sortedValues.SequenceEqual(new List<int> { 5 }))
        {
            return 7;
        }
        else if (sortedValues.SequenceEqual(new List<int> { 1, 4 }))
        {
            return 6;
        }
        else if (sortedValues.SequenceEqual(new List<int> { 2, 3 }))
        {
            return 5;
        }
        else if (sortedValues.SequenceEqual(new List<int> { 1, 1, 3 }))
        {
            return 4;
        }
        else if (sortedValues.SequenceEqual(new List<int> { 1, 2, 2 }))
        {
            return 3;
        }
        else if (sortedValues.SequenceEqual(new List<int> { 1, 1, 1, 2 }))
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    private static List<int> Key(Tuple<List<char>, int> hb)
    {
        var h = hb.Item1;
        var t = GetType(h);
        var key = new List<int> { t };
        key.AddRange(h.Select(c => scores[c]).ToList());
        return key;
    }

    public static int GetWinnings(List<Tuple<List<char>, int>> handBids)
    {
        var inOrder = handBids.OrderBy(x => Key(x), Comparer<List<int>>.Create((a, b) => CompareKeys(a, b))).ToList();
        var total = 0;
        var rank = 1;
        foreach (var hb in inOrder)
        {
            total += hb.Item2 * rank;
            rank++;
        }
        return total;
    }

    private static int CompareKeys(List<int> a, List<int> b)
    {
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
            {
                return a[i].CompareTo(b[i]);
            }
        }
        return 0;
    }

    public static string Parse(string input, bool isPartB = false)
    {
        var handBids = new List<Tuple<List<char>, int>>();
        var lines = input.Split("\n");

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            var split = line.Split();
            var hand = split[0].ToCharArray().ToList();
            var bid = int.Parse(split[1]);
            handBids.Add(new Tuple<List<char>, int>(hand, bid));
        }

        if (!isPartB)
        {
            return GetWinnings(handBids).ToString();
        }
        else
        {

            scores['J'] = 0;
            part = 2;

            return GetWinnings(handBids).ToString();
        }
    }
}








