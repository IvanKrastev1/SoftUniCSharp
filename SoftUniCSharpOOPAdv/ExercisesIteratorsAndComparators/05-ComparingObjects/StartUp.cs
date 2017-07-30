using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static void Main()
    {
        IList<Person> people = new List<Person>();
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split();
            people.Add(new Person(args[0], int.Parse(args[1]), args[2]));
        }
        int personIndex = int.Parse(Console.ReadLine()) -1;

        if (people.Count(x => x.CompareTo(people[personIndex]) == 0) > 1)
        {
            int equalPeople = people.Count(p => p.CompareTo(people[personIndex]) == 0);
            int unequalPeople = people.Count(p => p.CompareTo(people[personIndex]) != 0);

            Console.WriteLine($"{equalPeople} {unequalPeople} {people.Count}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}
