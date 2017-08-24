using System;
using System.Collections.Generic;

namespace _04_CubicAssault
{
    using System.Linq;

    public class StartUp

    {
        public static int ConvertThreshold = 1_000_000;

        public static void Main(string[] args)
        {
            var meteorNames = new List<string>() { "Green", "Red", "Black" };
            var regions = new Dictionary<string, Dictionary<string, long>>();
            string inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "Count em all")
            {
                var regionTokens = inputLine.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var regionName = regionTokens[0];
                var meteorType = regionTokens[1];
                var meteorCount = int.Parse(regionTokens[2]);

                if (!regions.ContainsKey(regionName))
                {
                    regions[regionName] = new Dictionary<string, long>() { { "Green", 0 }, { "Red", 0 }, { "Black", 0 } };
                }

                regions[regionName][meteorType] += meteorCount;

                for (int i = 0; i < meteorNames.Count - 1; i++)
                {
                    var nextTypeCount = regions[regionName][meteorNames[i]] / ConvertThreshold;
                    if (nextTypeCount > 0)
                    {
                        regions[regionName][meteorNames[i + 1]] += nextTypeCount;
                        regions[regionName][meteorNames[i]] %= ConvertThreshold;
                    }
                }
            }

            var orderedRegions = regions
                .OrderByDescending(r => r.Value["Black"])
                .ThenBy(n => n.Key.Length)
                .ThenBy(r => r.Key)
                .ToDictionary(r => r.Key, r => r.Value);

            foreach (var orderedRegion in orderedRegions)
            {
                Console.WriteLine(orderedRegion.Key);
                foreach (var meteorType in orderedRegion.Value.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {meteorType.Key} : {meteorType.Value}");
                }
            }
        }
    }
}
