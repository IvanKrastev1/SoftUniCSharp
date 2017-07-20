using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        string driver = Console.ReadLine();
        var car = new Ferrari(driver);

        Console.WriteLine($"{car.Model}/{car.PushBrakes()}/{car.PushGasPedal()}/{car.Driver}");
    }
}