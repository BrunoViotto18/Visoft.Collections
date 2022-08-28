using System.Collections;

namespace MyLINQ;


public struct MyList<T> : IEnumerable<T>
{
    private T[] Array { get; set; }
    public int Count { get; private set; }

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

    public MyList()
    {
        Array = new T[10];
        Count = 0;
    }

    public MyList(params T[] array)
    {
        this.Array = array;
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


    /* Enumerators */

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
            yield return Array[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();


    /* Override Methods */

    public override string ToString()
        => $"[{String.Join(", ", Array.Take(Count))}]";
}
