namespace Domain.Primitives;

public abstract class Entity(Guid id) : IEquatable<Entity>
{
    protected Guid Id { get; private init; } = id;

    public static bool operator ==(Entity? left, Entity? right) =>
        left is not null && right is not null && left.Id == right.Id;

    public static bool operator !=(Entity? left, Entity? right) => !(left == right);

    public override bool Equals(object? obj) => obj is Entity entity && Equals(entity);

    public bool Equals(Entity? other) => other is not null && Id == other.Id;

    public override int GetHashCode() => Id.GetHashCode() * 41;
}
