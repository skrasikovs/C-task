using System;

public class Customer
{
    public string Name { get; set; }
    public double TotalSpent { get; set; }

    public double CalculateLoyaltyDiscount(double discountRate = 0.05, double minPurchase = 100)
    {
        if (TotalSpent >= minPurchase)
        {
            return TotalSpent * discountRate;
        }
        return 0;
    }
}

public static class CustomerExtensions
{
    public static void Greet(this Customer customer, string prefix = "Welcome")
    {
        Console.WriteLine($"{prefix}, {customer.Name}!");
    }
}

public class Program
{
    public static void Main()
    {
        var customer1 = new Customer { Name = "Alice", TotalSpent = 250 };
        var customer2 = new Customer { Name = "Bob", TotalSpent = 80 };

        customer1.Greet();
        double discount1 = customer1.CalculateLoyaltyDiscount(); // Uses default 5% and minPurchase = 100
        Console.WriteLine($"Discount for {customer1.Name}: ${discount1:F2}");

        customer2.Greet("Hello");
        double discount2 = customer2.CalculateLoyaltyDiscount(0.1); // Custom 10% rate, default minPurchase
        Console.WriteLine($"Discount for {customer2.Name}: ${discount2:F2}");
    }
}
