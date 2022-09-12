using System.Runtime.CompilerServices;

namespace Visoft.Collections;

using Interfaces;

public class FList<T> : IFList<T>
{
    private T[] _array;
    private const int DefaultSize = 8;
    public static readonly T[] Empty = new T[0];
    
    public int Count { get; private set; }
    public bool IsReadOnly => false;

    // TODO: Alterar de int para uint para aumentar o tamanho total válido da lista
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
        _array = Empty;
        Count = 0;
    }

    public FList(params T[] array)
    {
        _array = new T[array.Length];
        Array.Copy(array,_array, array.Length);
        Count = array.Length;
    }


    /* List Methods */

    private void Grow()
    {
        var array = _array;
        _array = new T[_array.Length == 0 ? DefaultSize : _array.Length * 2];
        Array.Copy(array, _array, Count);
    }
    
    public void Add(T item)
    {
        if (_array.Length == Count)
            Grow();
        _array[Count++] = item;
    }

    public void Clear()
    {
        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            Array.Clear(_array);
        Count = 0;
    }

    public bool Contains(T item)
    {
        int index = Array.IndexOf(_array, item, 0, Count);
        return index >= 0;
    }

    public void CopyTo(T[] array, int arrayIndex=0)
        => Array.Copy(_array, 0, array, arrayIndex, Count);
    
    // TODO: Talvez haja uma maneira de retirar o if (se vira eu do futuro) (vai se ferrar eu do passado)
    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index == -1)
            return false;
        
        Array.Copy(_array, index + 1, _array, index, Count-- - index - 1);
        
        return true;
    }

    public void RemoveAt(int index)
    {
        if (index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        
        Array.Copy(_array, index + 1, _array, index, Count-- - index - 1);
    }

    public int IndexOf(T item)
        => Array.IndexOf(_array, item, 0, Count);

    public void Insert(int index, T item)
    {
        if (index > Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (Count == _array.Length)
            Grow();
        
        Array.Copy(_array, index, _array, index + 1, Count++ - index);
        _array[index] = item;
    }
    
    
    /* Enumerator */

    public FListEnumerator<T> GetEnumerator()
        => new(_array, Count);


    /* Override Methods */

    public override string ToString()
        => $"[{String.Join(", ", _array.Take(Count))}]";
}
