namespace Visoft.Collections;

using Interfaces;

public struct FListEnumerator<T> : IFListEnumerator<T>
{
    private readonly T[] _array;
    private readonly int _length;
    private int _index = -1;
        
    public T Current => _array[_index];

    public FListEnumerator(T[] array, int length)
    {
        _array = array;
        _length = length;
    }

    public bool MoveNext()
    {
        return ++_index < _length;
    }

    public void Dispose()
    {
        
    }
}
