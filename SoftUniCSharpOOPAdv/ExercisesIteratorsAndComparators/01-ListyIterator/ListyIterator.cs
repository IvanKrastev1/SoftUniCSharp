using System;
using System.Collections;
using System.Collections.Generic;

public class ListlyIterator<T> : IEnumerable<T>
{
    private int index;

    public IList<T> Elements { get; private set; }

    public ListlyIterator(IEnumerable<T> items)

    {
        this.Elements = new List<T>();
        foreach (var elem in items)
        {
            this.Elements.Add(elem);
        }
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.index++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Print()
    {
        if (this.Elements.Count > 0)
        {
            Console.WriteLine(this.Elements[this.index]);
        }
        else
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }

    public bool HasNext()
    {
        if ((this.index + 1) < this.Elements.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public IEnumerator<T> GetEnumerator()
    {

        for (int i = 0; i < this.Elements.Count; i++)
        {
            yield return this.Elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
