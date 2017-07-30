using System;
using System.Linq;

internal class StartUp
{
    private static void Main()
    {
        string input = string.Empty;
        ListlyIterator<string> elements = null;
        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = args[0];
            try
            {
                switch (command)
                {
                    case "Create":
                        elements = new ListlyIterator<string>(args.Skip(1));
                        break;

                    case "Move":
                        Console.WriteLine(elements.Move());
                        break;

                    case "Print":
                        elements.Print();
                        break;

                    case "HasNext":
                        Console.WriteLine(elements.HasNext());
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
               
            }
        }
    }
}
