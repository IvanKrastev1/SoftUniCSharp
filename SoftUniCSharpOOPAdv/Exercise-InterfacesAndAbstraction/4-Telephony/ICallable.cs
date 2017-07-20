using System.Collections.Generic;

public interface ICallable
{
    ICollection<string> Numbers { get; }
    string Makecall(string number);
}
