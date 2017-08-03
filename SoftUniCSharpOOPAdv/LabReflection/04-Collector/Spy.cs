using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string investigatedClass)
    {
        var getClass = Type.GetType(investigatedClass);
        var getMethods = getClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        var sb = new StringBuilder();

        foreach (var method in getMethods.Where(f => f.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in getMethods.Where(f => f.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}
