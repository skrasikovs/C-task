using System;
using System.Collections.Generic;

public enum UserType
{
    Human,
    AI
}

public class GameUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserType Type { get; set; }
    public int Level { get; set; }

    public GameUser() : this(0, "Unknown", UserType.Human, 1)
    {
    }

    public GameUser(int id, string name) : this(id, name, UserType.Human, 1)
    {
    }

    public GameUser(int id, string name, UserType type, int level)
    {
        Id = id;
        Name = name;
        Type = type;
        Level = level;
        Console.WriteLine($"GameUser created: {Name} (ID: {Id}), Type: {Type}, Level: {Level}");
    }
}

public class HumanPlayer : GameUser
{
    public List<int> GameScores { get; set; }

    public HumanPlayer() : this(0, "Unknown Player", 1)
    {
    }

    public HumanPlayer(int id, string name) : this(id, name, 1)
    {
    }

    public HumanPlayer(int id, string name, int level) : base(id, name, UserType.Human, level)
    {
        GameScores = new List<int>();
        Console.WriteLine($"HumanPlayer created: {Name} with Level {Level}");
    }
}

public class Program
{
    public static void Main()
    {
        var user1 = new HumanPlayer();
        var user2 = new HumanPlayer(10, "Alice");
        var user3 = new HumanPlayer(20, "Bob", 5);
    }
}
