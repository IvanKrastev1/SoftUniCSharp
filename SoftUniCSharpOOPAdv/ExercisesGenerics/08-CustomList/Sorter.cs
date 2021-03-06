﻿
    using System;
    using System.Linq;

public class Sorter
    {
        public static CustomList<T> Sort<T>(CustomList<T> list)
        where T :  IComparable<T>
        {
            var temp = list.Elements.OrderBy(x => x);
        return new CustomList<T>(temp);

        }

    }
