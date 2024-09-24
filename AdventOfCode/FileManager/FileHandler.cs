namespace FileManager;

public class FileHandler
{
    private static string _basePath = @"C:\Users\tschaal\RiderProjects\AdventOfCode\AdventOfCode\Saves";
    
    static FileHandler()
    {
        if (!Directory.Exists(_basePath))
        {
            Directory.CreateDirectory(_basePath);
        }
    }
    
    public static void CreateFile(string projectName, string className, string content)
    {
        string projectPath = Path.Combine(_basePath, projectName);
        
        if (!Directory.Exists(projectPath))
        {
            Directory.CreateDirectory(projectPath);
        }
        
        string filePath = Path.Combine(projectPath, $"{className}.txt");
        
        File.WriteAllText(filePath, content);

        Console.WriteLine($"File created at: {filePath}");
    }
    
    public static string ReadFile(string projectName, string className)
    {
        string filePath = Path.Combine(_basePath, projectName, $"{className}.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return null;
        }
        return File.ReadAllText(filePath);
    }

    public static bool FileExists(string projectName, string className)
    {
        string filePath = Path.Combine(_basePath, projectName, $"{className}.txt");
        
        if (File.Exists(filePath))
        {
            return true;
        }
        return false;
    }
    
    public static void AppendToFile(string projectName, string className, string content)
    {
        string filePath = Path.Combine(_basePath, projectName, $"{className}.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return;
        }
        File.AppendAllText(filePath, content);
        Console.WriteLine("Content appended to file.");
    }
}