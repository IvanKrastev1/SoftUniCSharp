using System;

internal class StartUp
{
    private static void Main()
    {
        string[] strings = ArrayCreator.Create(5, "Pesho");
        int[] integers = ArrayCreator.Create(10, 33);

        Console.WriteLine(strings.ToString());
        Console.WriteLine(integers.ToString());
    }
}
