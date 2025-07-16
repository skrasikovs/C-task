public enum UserType
{
    Human,
    AI
}

public abstract class GameUserBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string Owner { get; set; }

    public UserType Type { get; set; }
    public int Level { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }

    public List<int> GameScores { get; set; } = new();

    public abstract void PlayGame();

    public virtual double GetAverageScore()
    {
        if (GameScores.Count == 0) return 0;
        return GameScores.Average();
    }

    public double GetWinRate()
    {
        int total = Wins + Losses;
        if (total == 0) return 0;
        return (double)Wins / total;
    }
}
