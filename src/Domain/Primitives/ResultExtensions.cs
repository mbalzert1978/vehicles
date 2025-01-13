namespace Domain.Primitives;

public static class ResultExtensions
{
    public static T? UnwrapOrDefault<T, E>(this Result<T, E> self)
        where T : notnull => self._isOk ? self._value : default;

    public static T UnwrapOr<T, E>(this Result<T, E> self, T @default)
        where T : notnull => self._isOk ? self._value! : Contracts.ThrowIfNull(@default);

    public static T UnwrapOrElse<T, E>(this Result<T, E> self, Func<E, T> op)
        where T : notnull => self._isOk ? self._value! : Contracts.ThrowIfNull(op)(self._error!);

    public static Option<T> Filter<T, E>(this Result<T, E> self, Func<T, bool> op)
        where T : notnull =>
        self._isOk && Contracts.ThrowIfNull(op)(self._value!)
            ? Option<T>.Some(self._value!)
            : Option<T>.None;

    public static bool IsOk<T, E>(this Result<T, E> self)
        where T : notnull => self._isOk;

    public static bool IsErr<T, E>(this Result<T, E> self)
        where T : notnull => !self._isOk;

    public static Option<T> Ok<T, E>(this Result<T, E> self)
        where T : notnull => self._isOk ? Option<T>.Some(self._value!) : Option<T>.None;

    public static Result<U, E> Map<T, U, E>(this Result<T, E> self, Func<T, U> op)
        where T : notnull
        where U : notnull =>
        self._isOk
            ? Result<U, E>.Ok(Contracts.ThrowIfNull(op)(self._value!))
            : Result<U, E>.Err(self._error!);

    public static Result<U, E> Map<T, U, E>(this Result<T, E> self, Func<T, Result<U, E>> op)
        where T : notnull
        where U : notnull =>
        self._isOk ? Contracts.ThrowIfNull(op)(self._value!) : Result<U, E>.Err(self._error!);

    public static Result<T, F> MapErr<T, E, F>(this Result<T, E> self, Func<E, F> op)
        where T : notnull
        where F : notnull =>
        self._isOk
            ? Result<T, F>.Ok(self._value!)
            : Result<T, F>.Err(Contracts.ThrowIfNull(op)(self._error!));

    public static IEnumerable<T?> Iter<T, E>(this Result<T, E> self)
        where T : notnull => self._isOk ? [self._value] : [];
}
