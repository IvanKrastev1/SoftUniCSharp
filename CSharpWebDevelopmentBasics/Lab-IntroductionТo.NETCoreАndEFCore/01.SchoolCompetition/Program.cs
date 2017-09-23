using System;
using System.Collections.Generic;

namespace _01_SchoolCompetition
{
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var results = new Dictionary<string, int>();
            var categories = new Dictionary<string, SortedSet<string>>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var parts = line.Split(' ');
                var name = parts[0];
                var category = parts[1];
                var points = int.Parse(parts[2]);

                if (!results.ContainsKey(name))
                {
                    results[name] = 0;
                }
                if (!categories.ContainsKey(name))
                {
                    categories[name] = new SortedSet<string>();
                }

                results[name] += points;
                categories[name].Add(category);
            }

            var orderedStudetns = results
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key);

            foreach (var student in orderedStudetns)
            {
                var name = student.Key;
                var result = student.Value;
                var studentCategories = categories[name];

                var categoriesText = $"[{string.Join(",", studentCategories)}]";

                Console.WriteLine($"{name}: {result} {categoriesText}");

            }


        }
    }
}
