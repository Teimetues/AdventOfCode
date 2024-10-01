﻿using System.Text;
using FileManager;

namespace Advent2015.Days;

public class Day5
{
    public static string PuzzleInput = FileHandler.ReadFile("Advent2015", "Day5");

    public static void GetNiceStringAmount(string input)
    {
        string[] words = input.Split(["\r\n", "\n"], StringSplitOptions.None);
        int sum = 0;

        foreach (string word in words)
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

        Console.WriteLine("Anzahl an Netten Wörtern mit Regel 1: " + sum);
        sum = 0;

        foreach (string word in words)
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
        Console.WriteLine("Anzahl an Netten Wörtern mit Regel 2: " + sum);
    }
    
    static bool ContainsPairTwice(string str)
    {
        for (int i = 0; i < str.Length - 1; i++)
        {
            string pair = str.Substring(i, 2);
            if (str.IndexOf(pair, i + 2) != -1)
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