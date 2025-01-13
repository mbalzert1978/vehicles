namespace Domain.Primitives;

public static class ResultFactories
{
    public static Result<T, string> Ok<T>(T value)
        where T : notnull => Result<T, string>.Ok(value);

    public static Result<T, string> Err<T>(string error)
        where T : notnull => Result<T, string>.Err(error);

    public static Result<T, E> Ok<T, E>(T value)
        where T : notnull => Result<T, E>.Ok(value);

    public static Result<T, E> Err<T, E>(E error)
        where T : notnull => Result<T, E>.Err(error);
}
