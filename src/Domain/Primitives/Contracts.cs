namespace Domain.Primitives;

public static class Contracts
{
    public static T ThrowIfNull<T>(T? value) =>
        value ?? throw new ArgumentNullException(nameof(value));
}
