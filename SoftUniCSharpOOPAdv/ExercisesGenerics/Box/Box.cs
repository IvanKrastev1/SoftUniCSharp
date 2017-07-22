
    using System;public class Box<T> 
    {
        public T Value { get; private set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value}";
        }

        
    }