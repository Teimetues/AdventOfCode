using System.Collections;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Text;
using FileManager;

namespace Advent2015.Days;

public class Day4
{
    public static string[] MineCoin()
    {
        string key = FileHandler.ReadFile("Advent2015", "Day4");
        string[] line = [CalcZeros(5, key), CalcZeros(6, key)];
        return line;
    }

    public static string CalcZeros(int zeros, string key)
    {
        string required = new string('0', zeros);
        using (MD5 md5 = MD5.Create())
        {
            int number = 1;

            while (true)
            {
                string input = key + number;
                byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                string hash = Convert.ToHexString(hashBytes);

                if (hash.StartsWith(required))
                {
                    string adventCoins = $"AdventCoin {zeros}*0: {number}";
                    Console.WriteLine(adventCoins);
                    return adventCoins;
                }
                number++;
            }
        }
    }
}