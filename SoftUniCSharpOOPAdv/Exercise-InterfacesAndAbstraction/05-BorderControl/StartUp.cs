using System;
using System.Collections.Generic;
using System.Linq;


public class StartUp
{
    private static void Main(string[] args)
    {
        var input = string.Empty;
        ICollection<IBeing> beings = new List<IBeing>();
        while ((input = Console.ReadLine()) != "End")
        {
            
            var token = input.Split();

            if (token.Length == 3)
            {
                beings.Add(new Citizen(token[0], int.Parse(token[1]), token[2]));
            }
            else
            {
                beings.Add(new Robot(token[0], token[1]));
            }
        }

        string FakeId = Console.ReadLine();
        beings.Where(b => b.Id.EndsWith(FakeId)).ToList().ForEach(i => Console.WriteLine(i.Id));

    }
}