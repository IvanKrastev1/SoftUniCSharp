 public interface ICustomList<T>
 {
     void Add(T element);
     T Remove(int index);
     string Contains(T element);
     void Swap(int index1, int index2);
     int CountGreaterThan(T element);
     T Max();
     T Min();
     void Print();

 }
