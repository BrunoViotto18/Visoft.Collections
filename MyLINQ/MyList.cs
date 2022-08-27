using System.Collections;

namespace MyLINQ;


public struct MyList<T> : IEnumerable<T>
{
    private T[] array { get; set; }
    public int Count { get; private set; }

    public T this[int index]
    {
        get => array[index];
        set => array[index] = value;
    }


    /* Construtores */

    public MyList()
    {
        array = new T[10];
        Count = 0;
    }

    public MyList(params T[] array)
    {
        this.array = array;
        Count = array.Length;
    }


    /* List Methods */

    public void Add(T item)
    {
        if (array.Length <= Count)
        {
            T[] a = new T[array.Length * 2];
            array.CopyTo(a, 0);
            array = a;
        }
        array[Count++] = item;
    }

    public void Clear()
        => Count = 0;

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
            if (array[i].Equals(item))
                return true;
        return false;
    }


    /* Enumerators */

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
            yield return array[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();


    /* Override Methods */

    public override string ToString()
        => $"[{String.Join(", ", array.Take(Count))}]";
}
