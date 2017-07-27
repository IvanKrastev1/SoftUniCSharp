using System;
using System.Linq;

public class StartUp

{
    public static void Main()
    {
        CustomList<string> customList = new CustomList<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(' ');
            switch (tokens[0])
            {
                case "Add":
                    customList.Add(tokens[1]);
                    break;

                case "Remove":
                    customList.Remove(int.Parse(tokens[1]));
                    break;

                case "Contains":
                    Console.WriteLine(customList.Contains(tokens[1]));
                    break;

                case "Swap":
                    customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;

                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(tokens[1]));
                    break;

                case "Max":
                    Console.WriteLine(customList.Max());
                    break;

                case "Min":
                    Console.WriteLine(customList.Min());
                    break;

                case "Print":
                    customList.Print();
                    break;
                case "Sort":
                    customList = Sorter.Sort(customList);
                    break;
            }
        }
        
    }
}
