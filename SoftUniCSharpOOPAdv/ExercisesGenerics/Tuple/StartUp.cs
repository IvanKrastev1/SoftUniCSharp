
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tuple;

class StartUp
    {
        static void Main(string[] args)
        {
        //var tokens = GetTokens();

        //CustomTuple<string, string> tupleOne = new CustomTuple<string, string>((tokens[0] + " " + tokens[1]), tokens[2]);

        //tokens = GetTokens();

        //CustomTuple<string, int> tupleTwo = new CustomTuple<string, int>(tokens[0], int.Parse(tokens[1]));

        //tokens = GetTokens();

        //CustomTuple<int, double> tupleThree = new CustomTuple<int, double>(int.Parse(tokens[0]), double.Parse(tokens[1]));

        //Console.WriteLine(tupleOne.ToString());
        //Console.WriteLine(tupleTwo.ToString());
        //Console.WriteLine(tupleThree.ToString());

            List<string> tokens = GetTokens();

            ThreeTuple.Threeuple<string, string, string> threeupleOne = new ThreeTuple.Threeuple<string, string, string>((tokens[0] + " " + tokens[1]), tokens[2], tokens[3]);

            tokens = GetTokens();

            ThreeTuple.Threeuple<string, int, bool> threeupleTwo = new ThreeTuple.Threeuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), tokens[2] == "drunk" ? true : false);

            tokens = GetTokens();

            ThreeTuple.Threeuple<string, double, string> threeupleThree = new ThreeTuple.Threeuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]);

            Console.WriteLine(threeupleOne);
            Console.WriteLine(threeupleTwo);
            Console.WriteLine(threeupleThree);

    }
        private static List<string> GetTokens()
        {
            return Console.ReadLine().Split(new[] { ' ' }).ToList();
        }

}

