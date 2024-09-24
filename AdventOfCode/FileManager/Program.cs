namespace FileManager;

class Program
{
    static void Main(string[] args)
    {
        
        for (int i = 1; i <= 25; i++)
        {
            if (!FileHandler.FileExists("Advent2015", "Day"+i))
            {
                FileHandler.CreateFile("Advent2015", "Day"+i, "null");
            }
        }
    }
}