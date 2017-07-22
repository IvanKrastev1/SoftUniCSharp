using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;

public class StartUp
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Box<double>> listOfBoxes = new List<Box<double>>();
        for (int i = 0; i < n; i++)
        {
            Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
            listOfBoxes.Add(box);
        }
        //var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //Swapper.Swap(listOfBoxes,indexes[0],indexes[1]);
        //foreach (var box in listOfBoxes)
        //{
        //    Console.WriteLine(box);
        //}

        var compareElement =double.Parse( Console.ReadLine());
        Console.WriteLine(Compare.CompareElement(listOfBoxes,compareElement));
        
    }
}
