namespace Domain.Primitives;

public readonly struct Option<T>(T value) : IEquatable<Option<T>>
    where T : notnull
{
    public static Option<T> None
    {
        get => default;
    }

    public static Option<T> Some(T value) => new(value);

    internal readonly bool _isSome = value is not null;
    internal readonly T _value = Contracts.ThrowIfNull(value);

    public override bool Equals(object? obj) => obj is Option<T> other && Equals(other);

    public bool Equals(Option<T> other) =>
        _isSome == other._isSome && EqualityComparer<T>.Default.Equals(_value, other._value);

    public override int GetHashCode() => HashCode.Combine(_isSome, _value);

    public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);

    public static bool operator !=(Option<T> left, Option<T> right) => !(left == right);
}
