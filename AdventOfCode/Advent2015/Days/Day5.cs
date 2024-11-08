using System.Text;
using FileManager;

namespace Advent2015.Days;

public class Day5
{

    public static string[] SolvePuzzle()
    {
        string[] input = FileHandler.ReadFile("Advent2015", "Day5").Split(["\r\n", "\n"], StringSplitOptions.None);
        return [RuleOne(input), RuleTwo(input)];
    }

    private static string RuleOne(string[] input)
    {
        var sum = 0;

        foreach (string word in input)
        {
            bool isNice = true;
            int vowelsCount = word.Count(c => "aeiuo".Contains(c));

            if (vowelsCount < 3)
            {
                isNice = false;
            }

            if (!word.Where((_, i) => i > 0 && word[i] == word[i - 1]).Any())
            {
                isNice = false;
            }

            string[] forbiddenCombinations = ["ab", "cd", "pq", "xy"];

            if (forbiddenCombinations.Any(word.Contains))
            {
                isNice = false;
            }

            if (isNice)
            {
                sum++;
            }
        }

        string rule1 = "Anzahl an Netten Wörtern mit Regel 1: " + sum;
        Console.WriteLine(rule1);
        return rule1;
    }
    
    private static string RuleTwo(string[] input)
    {
        var sum = 0;

        foreach (string word in input)
        {
            bool isNice = ContainsPairTwice(word);

            if (!ContainsRepeatingLetterWithOneBetween(word))
            {
                isNice = false;
            }
            
            if (isNice)
            {
                sum++;
            }
        }

        string rule2 = "Anzahl an Netten Wörtern mit Regel 2: " + sum;
        Console.WriteLine(rule2);
        return rule2;
    }
    
    static bool ContainsPairTwice(string str)
    {
        for (int i = 0; i < str.Length - 1; i++)
        {
            string pair = str.Substring(i, 2);
            if (str.IndexOf(pair, i + 2, StringComparison.Ordinal) != -1)
            {
                return true;
            }
        }
        return false;
    }
    
    static bool ContainsRepeatingLetterWithOneBetween(string str)
    {
        for (int i = 0; i < str.Length - 2; i++)
        {
            if (str[i] == str[i + 2])
            {
                return true;
            }
        }
        return false;
    }
}