using System.Collections;
using FileManager;

namespace Advent2015.Days;

public class Day1
{
    static readonly string PuzzleInput = FileHandler.ReadFile("Advent2015", "Day1");

    public static string[] SolvePuzzle()
    {
        var list = PuzzleInput.ToCharArray().ToList();
        return [GetFloor(list), GetBasementEntry(list)];

    }
    private static string GetFloor(List<char> list)
    {
        int floor = 0;
        
        foreach (var commando in list)
        {
            switch (commando)
            {
                case '(':
                    floor++;
                    break;
                case ')':
                    floor--;
                    break;
            }
        }
        return "Santa's Position: "+floor;
    }

    private static string GetBasementEntry(List<char> list)
    {
        int floor = 0;
        int position = 0;
        
        foreach (var commando in list)
        {
            position++;
            switch (commando)
            {
                case '(':
                    floor++;
                    break;
                case ')':
                    floor--;
                    break;
            }
            if (floor < 0)
            {
                String basementLocation = "Charakter der in den Keller geht: "+position;
                Console.WriteLine(basementLocation);
                return basementLocation;
            }
        }
        return "Charakter der in den Keller geht ist nicht vorhanden.";
    }
}