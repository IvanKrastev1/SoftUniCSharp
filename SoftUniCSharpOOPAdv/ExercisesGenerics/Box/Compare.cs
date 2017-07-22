using System;
using System.Collections.Generic;
using System.Linq;

public class Compare
{
    public static int CompareElement<T>(List<Box<T>> listOfBoxes, T elementCompare)
        where T : IComparable<T>
    {
        var result = listOfBoxes.Count(b => b.Value.CompareTo(elementCompare) > 0);
        return result;
    }
}
