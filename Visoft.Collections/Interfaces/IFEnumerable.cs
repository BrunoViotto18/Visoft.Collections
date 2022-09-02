namespace Visoft.Collections.Interfaces;

public interface IFEnumerable<out T>
{
    public IEnumerator<T> GetEnumerator();
}
