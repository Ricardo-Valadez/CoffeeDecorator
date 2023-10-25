public abstract class Beverage
{
    public string Description { get; set; }
    public abstract double Cost { get; }
}

public class Espresso : Beverage
{
    public Espresso()
    {
        Description = "Espresso";
    }

    public override double Cost => 1.99;
}

public class HouseBlend : Beverage
{
    public HouseBlend()
    {
        Description = "House Blend Coffee";
    }

    public override double Cost => 0.89;
}

public abstract class CondimentDecorator : Beverage
{
    protected Beverage _beverage;

    public CondimentDecorator(Beverage beverage)
    {
        _beverage = beverage;
    }
}

public class Whip : CondimentDecorator
{
    public Whip(Beverage beverage) : base(beverage)
    {
        Description = _beverage.Description + ", Whip";
    }

    public override double Cost => _beverage.Cost + 0.10;
}

public class Mocha : CondimentDecorator
{
    public Mocha(Beverage beverage) : base(beverage)
    {
        Description = _beverage.Description + ", Mocha";
    }

    public override double Cost => _beverage.Cost + 0.20;
}

public class StarbuzzCoffee
{
    static void Main(string[] args)
    {
        Beverage beverage = null;

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Espresso");
            Console.WriteLine("2. House Blend Coffee");
            Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    beverage = new Espresso();
                    break;
                case "2":
                    beverage = new HouseBlend();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (beverage != null)
            {
                while (true)
                {
                    Console.WriteLine("Select a condiment:");
                    Console.WriteLine("1. Whip");
                    Console.WriteLine("2. Mocha");
                    Console.WriteLine("3. Done");

                    var condimentChoice = Console.ReadLine();

                    switch (condimentChoice)
                    {
                        case "1":
                            beverage = new Whip(beverage);
                            break;
                        case "2":
                            beverage = new Mocha(beverage);
                            break;
                        case "3":
                            Console.WriteLine("Your beverage:");
                            Console.WriteLine(beverage.Description);
                            Console.WriteLine("Total cost: $" + beverage.Cost);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    if (condimentChoice == "3")
                    {
                        break;
                    }
                }
            }
        }
    }
}