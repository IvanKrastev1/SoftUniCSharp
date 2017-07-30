using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var inputStones = Console.ReadLine()
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)

            .Select(int.Parse)
            .ToArray();

        Lake myLake = new Lake(inputStones);
        Console.WriteLine(string.Join(", ", myLake));
    }
}
