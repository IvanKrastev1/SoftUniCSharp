using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        var getClass = Type.GetType(className);
        var getClassFields = getClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        var getPublicMethod = getClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var getNonPublickMethod = getClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        foreach (var field in getClassFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in getNonPublickMethod.Where(g => g.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in getPublicMethod.Where(g => g.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}
