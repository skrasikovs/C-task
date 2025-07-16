public class GameScore
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
}

public class GameUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string Owner { get; set; }

    public List<GameScore> GameScores { get; set; } = new();
}
