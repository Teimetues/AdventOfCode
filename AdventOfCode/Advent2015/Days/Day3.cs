using System.Text;
using FileManager;

namespace Advent2015.Days;

public class Day3
{
    public static string PuzzleInput = FileHandler.ReadFile("Advent2015", "Day3");

    public static void CountHouses(string input)
    {
        int x = 0, y = 0;
        
        HashSet<(int, int)> houses = new HashSet<(int, int)>();

        houses.Add((x, y));

        foreach (char charakter in input)
        {
            switch (charakter)
            {
                case '^': y++; break; // North
                case 'v': y--; break; // South
                case '>': x++; break; // East
                case '<': x--; break; // West
            }
            houses.Add((x, y));
        }
        Console.WriteLine(houses.Count);
    }
}