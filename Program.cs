using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Beverage
{
    public abstract string Description { get; }
    public abstract double Cost { get; }
}

public class Espresso : Beverage
{
    public override string Description => "Espresso";

    public override double Cost => 1.99;
}

public class HouseBlend : Beverage
{
    public override string Description => "House Blend Coffee";

    public override double Cost => 0.89;
}

public abstract class CondimentDecorator : Beverage
{
}

public class Whip : CondimentDecorator
{
    private readonly Beverage _beverage;

    public Whip(Beverage beverage)
    {
        _beverage = beverage;
    }

    public override string Description => _beverage.Description + ", Whip";

    public override double Cost => _beverage.Cost + 0.10;
}

public class Mocha : CondimentDecorator
{
    private readonly Beverage _beverage;

    public Mocha(Beverage beverage)
    {
        _beverage = beverage;
    }

    public override string Description => _beverage.Description + ", Mocha";

    public override double Cost => _beverage.Cost + 0.20;
}

public class StarbuzzCoffee
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();
        double totalOrder = 0.0;

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Espresso");
            Console.WriteLine("2. House Blend Coffee");
            Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();

            if (choice == "3")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (choice != "1" && choice != "2")
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            Beverage beverage = null;
            if (choice == "1")
            {
                beverage = new Espresso();
            }
            else if (choice == "2")
            {
                beverage = new HouseBlend();
            }

            List<CondimentDecorator> condiments = new List<CondimentDecorator>();

            while (true)
            {
                Console.WriteLine("Select a condiment:");
                Console.WriteLine("1. Whip");
                Console.WriteLine("2. Mocha");
                Console.WriteLine("3. Done");

                var condimentChoice = Console.ReadLine();

                if (condimentChoice == "3")
                {
                    break;
                }

                if (condimentChoice != "1" && condimentChoice != "2")
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                if (condimentChoice == "1")
                {
                    beverage = new Whip(beverage);
                }
                else if (condimentChoice == "2")
                {
                    beverage = new Mocha(beverage);
                }
            }

            orders.Add(new Order(beverage));

            totalOrder += beverage.Cost;
        }

        Console.WriteLine("Order Summary:");
        foreach (var order in orders)
        {
            Console.WriteLine("Beverage: " + order.Beverage.Description);
            Console.WriteLine("Total Cost: $" + order.Beverage.Cost);
            Console.WriteLine();
        }

        double ivaRate = 0.16;
        double iva = totalOrder * ivaRate;
        double totalWithIVA = totalOrder + iva;

        Console.WriteLine("Subtotal: $" + totalOrder.ToString("0.00"));
        Console.WriteLine("IVA (16%): $" + iva.ToString("0.00"));
        Console.WriteLine("Total final: $" + totalWithIVA.ToString("0.00"));
    }
}

public class Order
{
    public Beverage Beverage { get; }

    public Order(Beverage beverage)
    {
        Beverage = beverage;
    }
}
