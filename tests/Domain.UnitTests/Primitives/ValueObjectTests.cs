using Domain.Primitives;

namespace Domain.UnitTests.Primitives;

public class ValueObjectTests
{
    private class TestValueObject : ValueObject
    {
        public TestValueObject(int value1, string value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public int Value1 { get; }
        public string Value2 { get; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value1;
            yield return Value2;
        }
    }

    [Fact]
    public void Equals_WhenValueObjectsAreEqual_ShouldReturnTrue()
    {
        TestValueObject left = new(1, "test");
        TestValueObject right = new(1, "test");

        Assert.True(left.Equals(right));
        Assert.True(left.Equals((object)right));
    }

    [Fact]
    public void Equals_WhenValueObjectsAreNotEqual_ShouldReturnFalse()
    {
        TestValueObject left = new(1, "test1");
        TestValueObject right = new(1, "test2");
        TestValueObject obj3 = new(2, "test1");

        Assert.False(left.Equals(right));
        Assert.False(left.Equals(obj3));
    }

    [Fact]
    public void EqualsOperator_WhenValueObjectsAreEqual_ShouldReturnTrue()
    {
        TestValueObject left = new(1, "test");
        TestValueObject right = new(1, "test");

        Assert.True(left == right);
    }

    [Fact]
    public void NotEqualsOperator_WhenValueObjectsAreNotEqual_ShouldReturnTrue()
    {
        TestValueObject left = new(1, "test1");
        TestValueObject right = new(1, "test2");

        Assert.True(left != right);
    }

    [Fact]
    public void GetHashCode_WhenValueObjectsAreEqual_ShouldReturnSameValue()
    {
        TestValueObject left = new(1, "test");
        TestValueObject right = new(1, "test");

        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void GetHashCode_WhenValueObjectsAreNotEqual_ShouldReturnDifferentValues()
    {
        TestValueObject left = new(1, "test1");
        TestValueObject right = new(1, "test2");

        Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
    }
}
