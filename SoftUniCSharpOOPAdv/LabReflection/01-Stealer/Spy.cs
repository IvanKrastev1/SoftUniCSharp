using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] fields)
    {
        var getClass = Type.GetType(investigatedClass);
        var classFields = getClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                             BindingFlags.NonPublic);

        var sb = new StringBuilder();
        var classIstance = Activator.CreateInstance(getClass, new object[] { });

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var fied in classFields.Where(f => fields.Contains(f.Name)))
        {
            sb.AppendLine($"{fied.Name} = {fied.GetValue(classIstance)}");
        }

        return sb.ToString().Trim();
    }
}
