namespace Domain.Primitives;

public static class OptionFactories
{
    public static Option<T> Some<T>(T value)
        where T : notnull => new(value);

    public static Option<T> None<T>()
        where T : notnull => Option<T>.None;
}
