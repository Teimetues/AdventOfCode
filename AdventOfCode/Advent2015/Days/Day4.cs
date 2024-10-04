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
      
      List<string> resultList = new List<string>();
      
      using (MD5 md5 = MD5.Create())
      {
         int number = 1;
         int i = 0;

         while (true)
         {
            string input = key + number;
            byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            
            if (hash.StartsWith("00000"))
            {
               if (i == 0)
               {
                  string adventCoins = "AdventCoin 5*0: " + number;
                  Console.WriteLine(adventCoins);
                  resultList.Add(adventCoins);
                  i++;
               }
               if (hash.StartsWith("000000"))
               {
                  string adventCoins = "AdventCoin 6*0: "+number;
                  Console.WriteLine(adventCoins);
                  resultList.Add(adventCoins);
                  break;
               }
            }
            number++;
         }
      }
      
      string[] result = resultList.ToArray();
      return result;
   }
}