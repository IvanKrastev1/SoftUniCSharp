using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : ICustomList<T>, IEnumerable<T>
    where T : IComparable<T>
{
    private readonly IList<T> elemetns;

    public CustomList() : this(Enumerable.Empty<T>())
    {
    }

    public CustomList(IEnumerable<T> collection)
    {
        this.elemetns = new List<T>(collection);
    }

    public IList<T> Elements
    {
        get => elemetns;
    }

    public void Add(T element)
    {
        this.elemetns.Add(element);
    }

    public T Remove(int index)
    {
        T temp = this.elemetns[index];
        this.elemetns.RemoveAt(index);
        return temp;
    }

    public string Contains(T element)
    {
        for (int i = 0; i < elemetns.Count; i++)
        {
            if ((elemetns[i].CompareTo(element) == 0))
            {
                return "True";
            }
        }
        return "False";
    }

    public void Swap(int index1, int index2)
    {
        var tempElement = elemetns[index1];
        elemetns[index1] = elemetns[index2];
        elemetns[index2] = tempElement;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        for (int i = 0; i < elemetns.Count; i++)
        {
            if (element.CompareTo(elemetns[i]) < 0)
            {
                count++;
            }
        }
        return count;
    }

    public T Max()
    {
        var maxElement = elemetns.Max();
        return maxElement;
    }

    public T Min()
    {
        var minElement = elemetns.Min();
        return minElement;
    }

    public void Print()
    {
        foreach (var element in elemetns)
        {
            Console.WriteLine(element);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.elemetns.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
