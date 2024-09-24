using FileManager;

namespace Advent2015.Days;

public class Day2
{
    
    public static string PuzzleInput = FileHandler.ReadFile("Advent2015", "Day2");
    
    public static void CalculateAmountOfPaper(string input)
    {
        
        string[] gifts = input.Trim().Split(['\n'], StringSplitOptions.RemoveEmptyEntries);

        int allPaper = 0;
        
        foreach (string gift in gifts)
        {
            string[] dimensions = gift.Split('x');
            int l = int.Parse(dimensions[0]);
            int w = int.Parse(dimensions[1]);
            int h = int.Parse(dimensions[2]);
            
            int surface = 2 * l * w + 2 * w * h + 2 * h * l;
            
            int small = Math.Min(l * w, Math.Min(w * h, h * l));
            
            int allNeed = surface + small;
            
            allPaper += allNeed;
        }
        
        Console.WriteLine("Benötigtes Papier "+ allPaper);
        CalculateAmountOfRibbon(gifts);
    }

    public static void CalculateAmountOfRibbon(string[] gifts)
    {
        int allRibbon = 0;
        foreach (string gift in gifts)
        {
            string[] dimensionen = gift.Split('x');
            int l = int.Parse(dimensionen[0]);
            int w = int.Parse(dimensionen[1]);
            int h = int.Parse(dimensionen[2]);
            
            int umfang = 2 * (Math.Min(l + w, Math.Min(w + h, h + l)));
            
            int volumen = l * w * h;
            
            int allNeed = umfang + volumen;
            
            allRibbon += allNeed;
        }

        Console.WriteLine("Benötigtes Band "+ allRibbon);
    }
}