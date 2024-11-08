using System.Collections;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Text;
using FileManager;

namespace Advent2015.Days;

public class Day4
{
    public static string[] SolvePuzzle()
    {
        var key = FileHandler.ReadFile("Advent2015", "Day4");
        string[] line = [CalcZeros(5, key), CalcZeros(6, key)];
        return line;
    }

    private static string CalcZeros(int zeros, string key)
    {
        var required = new string('0', zeros);
        var number = 1;

        while (true)
        {
            if (Convert.ToHexString(MD5.HashData(Encoding.ASCII.GetBytes(key + number))).StartsWith(required))
            {
                string adventCoins = $"AdventCoin {zeros}*0: {number}";
                Console.WriteLine(adventCoins);
                return adventCoins;
            }
            number++;
        }
    }
}