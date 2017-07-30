using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        SortedSet<Person> peplSortedByName = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> peplSortedByAge = new SortedSet<Person>(new AgeComparator());
        int peopleCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < peopleCount; i++)
        {
            var personTokens = Console.ReadLine().Split();
            Person person = new Person(personTokens[0], int.Parse(personTokens[1]));

            peplSortedByName.Add(person);
            peplSortedByAge.Add(person);

           
        }
        foreach (var person in peplSortedByName)
        {
            Console.WriteLine(person);
        }
        foreach (var person in peplSortedByAge)
        {
            Console.WriteLine(person);
        }
    }
}
