using System.Collections;

namespace MyLINQ;


public struct MyList<T> : IEnumerable<T>
{
    T[] array;
    public int Count { get; private set; }

    public T this[int index]
    {
        get => array[index];
        set => array[index] = value;
    }


    /* Construtores */

    public MyList()
    {
        array = new T[4];
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


    /* Enumerators */

    //public IEnumerator<T> GetEnumerator()
    //{
    //    for (int i = 0; i < array.Length; i++)
    //        yield return array[i];
    //}

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < array.Length; i++)
            yield return array[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();


    /* Override Methods */

    public override string ToString()
        => $"[{String.Join(", ", array.Take(Count))}]";
}
