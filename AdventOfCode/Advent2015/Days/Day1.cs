using System.Collections;
using FileManager;

namespace Advent2015.Days;

public class Day1
{
    static readonly string PuzzleInput = FileHandler.ReadFile("Advent2015", "Day1");

    
    public static string[] GetFloor()
    {
        List<char> list = PuzzleInput.ToCharArray().ToList();
        
        int floor = 0;
        int position = 0;
        bool found = false;

        string basementLocation = "";
        
        foreach (var commando in list)
        {
            position++;
            
            if (commando == '(')
            {
                floor++;
            }else if (commando == ')')
            {
                floor--;
            }
            
            if (floor < 0 && found == false)
            {
                basementLocation = "Charakter der in den Keller geht: "+position;
                Console.WriteLine(basementLocation);
                found = true;
            }
        }
        string santasPosition = "Santa's Position: "+floor;
        Console.WriteLine(santasPosition);
        string[] result = [santasPosition, basementLocation];
        return result;
    }
}