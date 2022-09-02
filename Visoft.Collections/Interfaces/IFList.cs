namespace Visoft.Collections.Interfaces;

public interface IFList<T> : IFEnumerable<T>
{
    public int Count { get; }
    public bool IsReadOnly { get; }
    public T this[int index] { get; set; }
    
    public void Add(T value);
    public void Clear();
    public bool Contains(T value);
    public void CopyTo(T[] array, int arrayIndex);
    public bool Remove(T value);
    public int IndexOf(T value);
    public void Insert(int index, T value);
    public void RemoveAt(int index);
}
