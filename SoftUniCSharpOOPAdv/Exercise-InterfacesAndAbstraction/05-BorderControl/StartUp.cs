using System;
using System.Collections.Generic;
using System.Linq;


public class StartUp
{
    private static void Main(string[] args)
    {
        var input = string.Empty;
        ICollection<IBeing> beings = new List<IBeing>();
        ICollection<IBirthable> livinBeings = new List<IBirthable>();
        while ((input = Console.ReadLine()) != "End")
        {
            
            var token = input.Split();
            if (token[0] == "Citizen")
            {
                livinBeings.Add(new Citizen(token[1],int.Parse(token[2]),token[3],token[4]));
            }
            else if (token[0] == "Robot")
            {
                beings.Add(new Robot(token[1],token[2]));
            }
            else
            {
                livinBeings.Add(new Pet(token[1],token[2]));
            }
            

           
        }

        string targetYear = Console.ReadLine();
        livinBeings.Where(b => b.Birthday.EndsWith(targetYear)).ToList().ForEach(i => Console.WriteLine(i.Birthday));

    }
}