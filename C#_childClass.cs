public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public void Start()
    {
        Console.WriteLine("Vehicle starting...");
    }

    public void Stop()
    {
        Console.WriteLine("Vehicle stopping...");
    }
}

public class Engine
{
    public int HorsePower { get; set; }
    public string Type { get; set; }

    public void Run()
    {
        Console.WriteLine($"Engine running with {HorsePower} HP ({Type}).");
    }
}

public class Car : Vehicle
{
    public Engine Engine { get; set; }

    public Car()
    {
        Engine = new Engine();
    }

    public void Drive()
    {
        Console.WriteLine($"Driving the {Make} {Model}...");
        Engine.Run();
    }
}

var myCar = new Car
{
    Make = "Tesla",
    Model = "Model S",
    Year = 2023,
    Engine = new Engine
    {
        HorsePower = 670,
        Type = "Electric"
    }
};

myCar.Start();
myCar.Drive();
myCar.Stop();