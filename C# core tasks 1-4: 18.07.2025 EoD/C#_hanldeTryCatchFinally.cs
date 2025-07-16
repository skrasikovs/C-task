using System;
using System.IO;

public class GameUser
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    public GameUser(string name)
    {
        Name = name;
        Level = 1;
        Experience = 0;
    }

    public void LoadUserData(string filePath)
    {
        FileStream fileStream = null;

        try
        {
            Console.WriteLine($"Attempting to load data for {Name} from {filePath}...");
            fileStream = File.OpenRead(filePath);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileStream = null; // Ownership passed to StreamReader
                Level = int.Parse(reader.ReadLine());
                Experience = int.Parse(reader.ReadLine());
                Console.WriteLine($"Data loaded. Level: {Level}, Experience: {Experience}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Save file not found.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Save file is corrupted or has invalid content.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            if (fileStream != null)
                fileStream.Dispose();

            Console.WriteLine("Finished attempting to load user data.\n");
        }
    }
}
