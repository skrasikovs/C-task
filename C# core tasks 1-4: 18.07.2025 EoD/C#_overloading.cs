using System;

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

    public void EarnExperience(int points)
    {
        Experience += points;
        Console.WriteLine($"{Name} earned {points} XP.");
        CheckLevelUp();
    }

    public void EarnExperience(int matchesPlayed, int xpPerMatch)
    {
        int totalXp = matchesPlayed * xpPerMatch;
        Experience += totalXp;
        Console.WriteLine($"{Name} played {matchesPlayed} matches and earned {totalXp} XP.");
        CheckLevelUp();
    }

    public void EarnExperience(int baseXP, double difficultyMultiplier)
    {
        int totalXp = (int)(baseXP * difficultyMultiplier);
        Experience += totalXp;
        Console.WriteLine($"{Name} earned {totalXp} XP with difficulty multiplier.");
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (Experience >= Level * 100)
        {
            Level++;
            Console.WriteLine($"{Name} leveled up to Level {Level}!");
        }
    }
}

public class Program
{
    public static void Main()
    {
        GameUser player = new GameUser("Alice");

        player.EarnExperience(50);
        player.EarnExperience(3, 40);
        player.EarnExperience(60, 1.5);
    }
}
