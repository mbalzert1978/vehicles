namespace Domain.Primitives;

public readonly struct Result<T, E> : IEquatable<Result<T, E>>
    where T : notnull
{
    internal readonly T? _value;
    internal readonly E? _error = default;
    internal readonly bool _isOk = false;

    private Result(T value)
    {
        _value = value;
        _error = default;
        _isOk = true;
    }

    private Result(E error)
    {
        _error = error;
        _value = default;
    }

    public override int GetHashCode() => HashCode.Combine(_isOk, _value, _error);

    public override bool Equals(object? obj) => obj is Result<T, E> other && Equals(other);

    public bool Equals(Result<T, E> other) =>
        _isOk == other._isOk
        && EqualityComparer<T>.Default.Equals(_value, other._value)
        && EqualityComparer<E>.Default.Equals(_error, other._error);

    public static bool operator ==(Result<T, E> left, Result<T, E> right) => left.Equals(right);

    public static bool operator !=(Result<T, E> left, Result<T, E> right) => !(left == right);

    public static Result<T, E> Ok(T value) => new(value);

    public static Result<T, E> Err(E error) => new(error);
}
