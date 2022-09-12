namespace Visoft.Collections.Interfaces;

public interface IFListEnumerator<out T> : IDisposable
{
    public T Current { get; }

    public bool MoveNext();
}
