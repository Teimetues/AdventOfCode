using FileManager;

namespace Advent2015.Days;

public class Day2
{

    public static string[] SolvePuzzle()
    {
        string[] gifts = FileHandler.ReadFile("Advent2015", "Day2").Trim().Split(['\n'], StringSplitOptions.RemoveEmptyEntries);
        return [CalculateAmountOfPaper(gifts), CalculateAmountOfRibbon(gifts)];
    }
    
    private static string CalculateAmountOfPaper(string[] gifts)
    {
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
        string needPaper = "Benötigtes Papier " + allPaper;
        Console.WriteLine(needPaper);
        return needPaper;
    }

    private static string CalculateAmountOfRibbon(string[] gifts)
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
        string needRibbon = "Benötigtes Band " + allRibbon;
        Console.WriteLine(needRibbon);
        return needRibbon;
    }
}