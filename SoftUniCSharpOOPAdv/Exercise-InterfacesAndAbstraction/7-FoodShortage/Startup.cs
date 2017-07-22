using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static void Main(string[] args)
    {
        ICollection<Rebel> rebels = new List<Rebel>();
        ICollection<Citizen> citizens = new List<Citizen>();
        var numberOfinputs = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfinputs; i++)
        {
            var input = Console.ReadLine().Split(new[] {' '});
            if (input.Length == 4)
            {
                citizens.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
            }
            else
            {
                rebels.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
            }
        }
        var buyer = string.Empty;

        while ((buyer = Console.ReadLine()) != "End")
        {
            if (rebels.Any(n => n.Name == buyer))
            {
                var rebel = rebels.First(n => n.Name == buyer);
                rebel.BuyFood();
            }
            else if(citizens.Any(n => n.Name == buyer))
            {
                var citizin = citizens.First(n => n.Name == buyer);
                citizin.BuyFood();
            }
           
        }

        int allFood = (citizens.Sum(f => f.Food))+ (rebels.Sum(f => f.Food));
        Console.WriteLine(allFood);
    }
}