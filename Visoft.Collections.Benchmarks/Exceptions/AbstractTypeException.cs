namespace Visoft.Collections.Benchmarks.Exceptions;

public class AbstractTypeException<T> : Exception
{
    public override string Message => $"The type \"{typeof(T)}\" is abstract.";
}
