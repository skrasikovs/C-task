using System;
using System.Collections.Generic;
using System.Linq;

public enum UserType
{
    Human,
    AI
}

public interface IGameUser
{
    int Id { get; set; }
    string Name { get; set; }
    string Species { get; set; }
    string Owner { get; set; }
    UserType Type { get; set; }
    int Level { get; set; }
    int Wins { get; set; }
    int Losses { get; set; }
    List<int> GameScores { get; set; }

    void PlayGame();
    double GetAverageScore();
    double GetWinRate();
}

public class HumanPlayer : IGameUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string Owner { get; set; }
    public UserType Type { get; set; } = UserType.Human;
    public int Level { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public List<int> GameScores { get; set; } = new();

    private readonly Random rand = new();

    public void PlayGame()
    {
        Console.WriteLine($"{Name} is playing the game.");

        int score = rand.Next(0, 101);
        GameScores.Add(score);

        if (score > 50)
            Wins++;
        else
            Losses++;
    }

    public double GetAverageScore()
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

    public override string ToString()
    {
        return $"{Name} (Level {Level}) - Wins: {Wins}, Losses: {Losses}, Avg Score: {GetAverageScore():F2}";
    }
}

public sealed class GameStatisticsManager
{
    private readonly List<IGameUser> _players;

    public GameStatisticsManager(List<IGameUser> players)
    {
        _players = players ?? throw new ArgumentNullException(nameof(players));
    }

    public double GetOverallAverageScore()
    {
        var allScores = _players.SelectMany(p => p.GameScores).ToList();
        if (!allScores.Any()) return 0;
        return allScores.Average();
    }

    public double GetOverallWinRate()
    {
        int totalWins = _players.Sum(p => p.Wins);
        int totalGames = _players.Sum(p => p.Wins + p.Losses);
        if (totalGames == 0) return 0;
        return (double)totalWins / totalGames;
    }

    public void PrintSummary()
    {
        Console.WriteLine("=== Game Statistics Summary ===");
        Console.WriteLine($"Total Players: {_players.Count}");
        Console.WriteLine($"Overall Average Score: {GetOverallAverageScore():F2}");
        Console.WriteLine($"Overall Win Rate: {GetOverallWinRate():P}");

        Console.WriteLine("\nIndividual Player Stats:");
        foreach (var player in _players)
        {
            Console.WriteLine(player);
        }
    }
}

public class Program
{
    public static void Main()
    {
        var players = new List<IGameUser>
        {
            new HumanPlayer
            {
                Id = 1,
                Name = "Alice",
                Species = "Human",
                Owner = "Self",
                Level = 5
            },
            new HumanPlayer
            {
                Id = 2,
                Name = "Bob",
                Species = "Human",
                Owner = "Self",
                Level = 3
            }
        };

        foreach (var player in players)
        {
            player.PlayGame();
            player.PlayGame();
            player.PlayGame();
        }

        var statsManager = new GameStatisticsManager(players);
        statsManager.PrintSummary();
    }
}
