using System.Buffers;

namespace Visoft.Collections;

using Visoft.Collections.Interfaces;

public class FList<T> : IFList<T>
{
    private T[] Array { get; set; }
    public int Count { get; private set; }
    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();
            return Array[index];
        }
        set
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();
            Array[index] = value;
        }
    }


    /* Construtores */

    public FList()
    {
        Array = new T[10];
        Count = 0;
    }

    public FList(params T[] array)
    {
        Array = array;
        Count = array.Length;
    }


    /* List Methods */

    public void Add(T item)
    {
        if (Array.Length <= Count)
        {
            var a = new T[Array.Length * 2];
            Array.CopyTo(a, 0);
            Array = a;
        }
        Array[Count++] = item;
    }

    public void Clear()
        => Count = 0;

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
            if (Equals(Array[i], item))
                return true;
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        for (int i = 0; i < Count; i++)
            array[i + arrayIndex] = Array[i];
    }
    
    public bool Remove(T item)
    {
        int index = -1;
        for (int i = 0; i < Count; i++)
            if (Equals(Array[i], item))
            {
                index = i;
                break;
            }

        if (index == -1)
            return false;
        
        for (int i = index; i < Count - 1; i++)
            Array[i] = Array[i + 1];
        Count--;
        return true;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
            
        for (int i = index; i < Count - 1; i++)
            Array[i] = Array[i + 1];
        Count--;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
            if (Equals(Array[i], item))
                return i;
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (Count == Array.Length)
        {
            T[] a = new T[Array.Length * 2];
            Array.CopyTo(a, 0);
            Array = a;
        }
        
        for (int i = Count; i > index; i--)
            Array[i] = Array[i - 1];
        Array[index] = item;
        Count++;
    }


    /* Enumerator */

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
            yield return Array[i];
    }
    

    /* Override Methods */

    public override string ToString()
        => $"[{String.Join(", ", Array.Take(Count))}]";
}
