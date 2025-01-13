namespace Domain.Primitives;

public static class OptionExtensions
{
    public static bool IsSome<T>(this Option<T> self)
        where T : notnull => self._isSome;

    public static bool IsNone<T>(this Option<T> self)
        where T : notnull => !self._isSome;

    public static Option<U> Map<T, U>(this Option<T> self, Func<T, U> op)
        where T : notnull
        where U : notnull =>
        self._isSome ? Option<U>.Some(Contracts.ThrowIfNull(op)(self._value)) : Option<U>.None;

    public static Option<U> Map<T, U>(this Option<T> self, Func<T, Option<U>> op)
        where T : notnull
        where U : notnull => self._isSome ? Contracts.ThrowIfNull(op)(self._value) : Option<U>.None;

    public static T Or<T>(this Option<T> self, T @default)
        where T : notnull => self._isSome ? self._value : @default;

    public static T Or<T>(this Option<T> self, Func<T> op)
        where T : notnull => self._isSome ? self._value : Contracts.ThrowIfNull(op)();
}
