using System;

namespace _03_CubicsMessages
{
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp

    {
        private static void Main(string[] args)
        {
            var patternValidation = "(^\\d+)([a-zA-Z]+)([^a-zA-Z]*$)";

            var inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "Over!")
            {
                var messagelenght = int.Parse(Console.ReadLine());
                var match = Regex.Match(inputLine, patternValidation);

                if (match.Success)
                {
                    var prefix = match.Groups[1].Value;
                    var message = match.Groups[2].Value;
                    var ending = string.Empty;
                    if (match.Groups[3].Value != "")
                    {
                        ending = match.Groups[3].Value;
                    }
                    if (message.Length != messagelenght)
                    {
                        continue;
                    }
                    var indexes = Regex.Replace(prefix + ending, @"\D*", String.Empty);
                    var sb = new StringBuilder();
                    foreach (var index in indexes)
                    {
                        var ind = int.Parse(index.ToString());
                        if (ind >= 0 && ind < messagelenght)
                        {
                            sb.Append(message[ind]);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }
                    Console.WriteLine($"{message} == {sb}");
                }
            }
        }
    }
}
