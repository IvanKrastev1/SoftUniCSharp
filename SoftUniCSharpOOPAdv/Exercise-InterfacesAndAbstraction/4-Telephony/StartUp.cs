using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        ICollection<string> numbers = Console.ReadLine().Split(new[] { ' ' });
        ICollection<string> urls = Console.ReadLine().Split(new[] { ' ' });

        var smartphone = new Smartphone(numbers,urls);

        Console.WriteLine(smartphone.ToString());

    }
}