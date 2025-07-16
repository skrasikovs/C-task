using System;

public class InvalidLevelUpException : Exception
{
    public int RequiredXP { get; }
    public int CurrentXP { get; }

    public InvalidLevelUpException(string message, int requiredXP, int currentXP)
        : base(message)
    {
        RequiredXP = requiredXP;
        CurrentXP = currentXP;
    }
}

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

    public void AddExperience(int xp)
    {
        Experience += xp;
        Console.WriteLine($"{Name} gained {xp} XP. Total: {Experience}");
    }

    public void TryManualLevelUp()
    {
        try
        {
            LevelUp();
        }
        catch (InvalidLevelUpException ex) when (ex.RequiredXP - ex.CurrentXP <= 20)
        {
            Console.WriteLine($"Almost there! You need just {ex.RequiredXP - ex.CurrentXP} more XP.");
        }
        catch (InvalidLevelUpException ex)
        {
            Console.WriteLine($"Level up failed: {ex.Message} (You have {ex.CurrentXP}/{ex.RequiredXP} XP)");
        }
    }

    private void LevelUp()
    {
        int requiredXP = Level * 100;

        if (Experience < requiredXP)
        {
            throw new InvalidLevelUpException("Not enough experience to level up.", requiredXP, Experience);
        }

        Experience -= requiredXP;
        Level++;
        Console.WriteLine($"{Name} has leveled up to level {Level}!");
    }
}
