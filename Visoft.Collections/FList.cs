namespace Visoft.Collections;

using Interfaces;

public class FList<T> : IFList<T>
{
    private T[] _array;
    public int Count { get; private set; }
    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();
            return _array[index];
        }
        set
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();
            _array[index] = value;
        }
    }


    /* Construtores */

    public FList()
    {
        _array = new T[10];
        Count = 0;
    }

    public FList(params T[] array)
    {
        _array = array;
        Count = array.Length;
    }


    /* List Methods */

    public void Add(T item)
    {
        if (_array.Length <= Count)
        {
            var array = new T[_array.Length * 2];
            Array.Copy(_array, array, Count);
            _array = array;
        }
        _array[Count++] = item;
    }

    public void Clear()
        => Count = 0;

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
            if (Equals(_array[i], item))
                return true;
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        for (int i = 0; i < Count; i++)
            array[i + arrayIndex] = _array[i];
    }
    
    public bool Remove(T item)
    {
        int index = -1;
        for (int i = 0; i < Count; i++)
            if (Equals(_array[i], item))
            {
                index = i;
                break;
            }

        if (index == -1)
            return false;
        
        for (int i = index; i < Count - 1; i++)
            _array[i] = _array[i + 1];
        Count--;
        return true;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
            
        for (int i = index; i < Count - 1; i++)
            _array[i] = _array[i + 1];
        Count--;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
            if (Equals(_array[i], item))
                return i;
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (Count == _array.Length)
        {
            T[] a = new T[_array.Length * 2];
            _array.CopyTo(a, 0);
            _array = a;
        }
        
        for (int i = Count; i > index; i--)
            _array[i] = _array[i - 1];
        _array[index] = item;
        Count++;
    }


    /* Override Methods */

    public override string ToString()
        => $"[{String.Join(", ", _array.Take(Count))}]";


    /* Enumerator */

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
            yield return _array[i];
    }
}
