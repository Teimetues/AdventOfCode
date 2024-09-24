using FileManager;

namespace Advent2015.Days;

public class Day1
{
    static readonly string PuzzleInput = FileHandler.ReadFile("Advent2015", "Day1");
    public static List<char> list = PuzzleInput.ToCharArray().ToList();

    
    public static void SendFloor(List<char> input)
    {
        int floor = 0;
        int position = 0;
        bool found = false;

        foreach (var commando in input)
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
                Console.WriteLine("Charakter der in den Keller geht: "+position);
                found = true;
            }
        }
        Console.WriteLine("Santas Position: "+floor);
    }
}