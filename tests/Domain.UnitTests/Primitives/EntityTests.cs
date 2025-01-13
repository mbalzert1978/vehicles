using Domain.Primitives;

namespace Domain.UnitTests.Primitives;

public class EntityTests
{
    private class FakeEntityA(Guid id) : Entity(id) { }

    private class FakeEntityB(Guid id) : Entity(id) { }

    private static (FakeEntityA, FakeEntityB) Setup()
    {
        FakeEntityA a = new(Guid.NewGuid());
        FakeEntityB b = new(Guid.NewGuid());
        return (a, b);
    }

    [Fact]
    public void Entity_WhenEntitiesAreEqual_ShouldReturnSameHashCode()
    {
        Guid id = Guid.NewGuid();
        Assert.Equal(new FakeEntityA(id).GetHashCode(), new FakeEntityA(id).GetHashCode());
    }

    [Fact]
    public void Entity_WhenComparedToAnotherEntityOfDifferentType_ShouldNotBeEqual()
    {
        (FakeEntityA a, FakeEntityB b) = Setup();

        Assert.False(a == b);
        Assert.True(a != b);
    }

    [Fact]
    public void Entity_WhenComparedToAnotherEntityOfDifferentTypeUsingEqualsMethod_ShouldReturnFalse()
    {
        (FakeEntityA a, FakeEntityB b) = Setup();

        Assert.False(a.Equals(b));
        Assert.False(a.Equals((object)b));
    }

    [Fact]
    public void Entity_WhenComparedToAnotherEntityOfDifferentTypeUsingIEquatableInterface_ShouldReturnFalse()
    {
        (FakeEntityA a, FakeEntityB b) = Setup();

        Assert.False(((IEquatable<Entity>)a).Equals(b));
    }

    [Fact]
    public void Entity_WhenComparedToAnotherEntityOfDifferentTypeUsingObjectReferenceEquals_ShouldReturnFalse()
    {
        (FakeEntityA a, FakeEntityB b) = Setup();

        Assert.False(ReferenceEquals(a, b));
    }

    [Fact]
    public void Entity_WhenComparedToNullUsingObjectReferenceEquals_ShouldReturnFalse()
    {
        FakeEntityA a = new(Guid.NewGuid());
        Entity? b = null;

        Assert.False(ReferenceEquals(a, b));
    }
}
