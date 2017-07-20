using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Smartphone : IBrowsable,ICallable
{
    public ICollection<string> Numbers { get; private set; }
    public ICollection<string> Urls { get; private set; }
    

    public Smartphone(ICollection<string> numbers,ICollection<string> urls)
    {
        this.Urls = new List<string>(urls);
        this.Numbers = new List<string>(numbers);
    }

    

    public string Browse(string url)
    {
        if (url.Any(char.IsDigit))
        {
            return "Invalid URL!";
        }
        else
        {
            return $"Browsing: {url}!";
        }
    }


    public string Makecall(string number)
    {
        if (!number.All(char.IsDigit))
        {
            return "Invalid number!";
        }
        else
        {
            return $"Calling... {number}";
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var number in Numbers)
        {
            sb.AppendLine(Makecall(number));
        }
        foreach (var url in Urls)
        {
            sb.AppendLine(Browse(url));
        }

        return sb.ToString();

    }
}