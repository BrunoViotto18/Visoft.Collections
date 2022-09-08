namespace Visoft.Collections.Benchmarks.Exceptions;

public class TypeAttributeException<T> : Exception
{
    private readonly string _attributes;
    public override string Message => $"The type \"{typeof(T)}\" doesn't have one or more of the following attributes: {_attributes}.";
    
    public TypeAttributeException(params string[] attributes)
    {
        if (attributes.Length <= 0)
            throw new ArgumentException($"No attribute names were given for the \"{nameof(TypeAttributeException<T>)}\".");
        _attributes = string.Join(", ", attributes);
    }
}
