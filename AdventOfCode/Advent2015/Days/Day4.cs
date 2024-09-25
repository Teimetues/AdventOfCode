using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Text;
using FileManager;

namespace Advent2015.Days;

public class Day4
{
   
   public static string PuzzleInput = FileHandler.ReadFile("Advent2015", "Day4");
   
   public static void MineCoin(string key)
   {
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
                  Console.WriteLine("AdventCoin 5*0: " + number);
                  i++;
               }
               if (hash.StartsWith("000000"))
               {
                  Console.WriteLine("AdventCoin 6*0: "+number);
                  break;
               }
            }
            number++;
         }
      }
   }
}