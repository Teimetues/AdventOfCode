using FileManager;

namespace Advent2015.Days;

public class Day6
{
    public static string PuzzleInput = FileHandler.ReadFile("Advent2015", "Day6");
    
    public static string[] Lights()
    {
        
        bool[,] grid = new bool[1000, 1000];
        int[,] grid2 = new int[1000, 1000];
        
        List<string> instructions = [..PuzzleInput.Split('\n')];
        
        foreach (string instruction in instructions)
        {
            ProcessInstruction(grid, grid2, instruction);
        }
        
        int count1 = CountLights(grid);
        string litLights = $"Anzahl der eingeschalteten Lichter: {count1}";
        Console.WriteLine(litLights);
        int count2 = CountTotalBrightness(grid2);
        string brightness = $"Gesamte helligkeit: {count2}";
        Console.WriteLine(brightness);
        
        return [litLights, brightness];
    }

    static void ProcessInstruction(bool[,] grid, int[,] grid2, string instruction)
    {
        
        int actionValue = GetActionValue(instruction);
        string[] parts = instruction.Split(' ');
        string action = parts[0] == "toggle" ? "toggle" : parts[1];
        string[] startCoords = parts[parts.Length - 3].Split(',');
        string[] endCoords = parts[parts.Length - 1].Split(',');

        int startX = int.Parse(startCoords[0]);
        int startY = int.Parse(startCoords[1]);
        int endX = int.Parse(endCoords[0]);
        int endY = int.Parse(endCoords[1]);
        

        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                if (action == "on")
                {
                    grid[x, y] = true;
                    grid2[x, y] = Math.Max(0, grid2[x, y] + actionValue);
                }
                else if (action == "off")
                {
                    grid[x, y] = false;
                    grid2[x, y] = Math.Max(0, grid2[x, y] + actionValue);
                }
                else if (action == "toggle")
                {
                    grid[x, y] = !grid[x, y];
                    grid2[x, y] = Math.Max(0, grid2[x, y] + actionValue);
                }
            }
        }
    }

    static int GetActionValue(string instruction)
    {
        if (instruction.StartsWith("turn on"))
        {
            return 1;
        }
        if (instruction.StartsWith("turn off"))
        {
            return -1;
        }
        return 2;
    }

    static int CountLights(bool[,] grid)
    {
        int count = 0;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (grid[x, y])
                {
                    count++;
                }
            }
        }
        return count;
    }
    
    
    static int CountTotalBrightness(int[,] grid)
    {
        int totalBrightness = 0;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                totalBrightness += grid[x, y];
            }
        }
        return totalBrightness;
    }
}