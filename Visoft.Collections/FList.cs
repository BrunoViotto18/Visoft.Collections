namespace Visoft.Collections;

using Interfaces;

public class FList<T> : IFList<T>
{
    private T[] _array;
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
        _array = new T[10];
        Count = 0;
    }

    public FList(params T[] array)
    {
        _array = new T[array.Length];
        Array.Copy(array,_array, array.Length);
        Count = array.Length;
    }


    /* List Methods */

    public void Add(T item)
    {
        if (_array.Length <= Count)
        {
            var array = new T[_array.Length * 2];
            for (int i = 0; i < Count; i++)
                array[i] = _array[i];
            //Array.Copy(_array, array, Count);
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

    public void CopyTo(T[] array, int arrayIndex=0)
    {
        Array.Copy(_array, 0, array, arrayIndex, Count);
    }
    
    // TODO: Talvez haja uma maneira de retirar o if (se vira eu do futuro)
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
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
            
        for (int i = index; i < Count - 1; i++)
            _array[i] = this[i + 1];
        Count--;
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_array, item, 0, Count);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (Count == _array.Length)
        {
            T[] array = new T[_array.Length * 2];
            for (int i = 0; i < Count; i++)
                array[i] = _array[i];
            _array = array;
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
