using System.Text;
using FileManager;

namespace Advent2015.Days;

public class Day3
{

    public static string[] SolvePuzzle()
    {
        string input = FileHandler.ReadFile("Advent2015", "Day3");
        return [CountHousesWithSanta(input),CountHousesWithSantaAndRobo(input)];

    }
    

    private static string CountHousesWithSanta(string input)
    {
        
        int x = 0, y = 0;
        var santa = true;
        
        HashSet<(int, int)> houses = new HashSet<(int, int)>();

        houses.Add((x, y));

        foreach (var charakter in input)
        {
            switch (charakter)
            {
                case '^': y++; break;
                case 'v': y--; break;
                case '>': x++; break;
                case '<': x--; break;
            }
            houses.Add((x, y));
        }
        string housesWithoutRobo = "Häuser ohne RoboSanta: "+houses.Count;
        Console.WriteLine(housesWithoutRobo);
        return housesWithoutRobo;
    }

    private static string CountHousesWithSantaAndRobo(string input)
    {
        int x1 = 0, y1 = 0;
        int x2 = 0, y2 = 0;
        bool santa = true;
        
        HashSet<(int, int)> houses = new HashSet<(int, int)>();
        houses.Add((x1, y1));
        
        foreach (char charakter in input)
        {
            if (santa)
            {
                switch (charakter)
                {
                    case '^': y1++; break;
                    case 'v': y1--; break;
                    case '>': x1++; break;
                    case '<': x1--; break;
                }
                houses.Add((x1, y1));
                santa = false;
            }
            else
            {
                switch (charakter)
                {
                    case '^': y2++; break;
                    case 'v': y2--; break;
                    case '>': x2++; break;
                    case '<': x2--; break;
                }
                houses.Add((x2, y2));
                santa = true;
            }
        }
        string housesWithRobo = "Häuser mit RoboSanta: "+houses.Count;
        Console.WriteLine(housesWithRobo);
        return housesWithRobo;
    }
}