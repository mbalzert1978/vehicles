namespace Domain.UnitTests.Primitives;

using static Domain.Primitives.ResultFactories;

public class ResultTests
{
    [Fact]
    public void GetHashCode_WhenResultsAreEqual_ShouldReturnSameHashCode()
    {
        Assert.Equal(Ok(5).GetHashCode(), Ok(5).GetHashCode());
        Assert.Equal(Err<int>("Error").GetHashCode(), Err<int>("Error").GetHashCode());
    }

    [Fact]
    public void Equals_WhenResultsAreEqual_ShouldReturnTrue()
    {
        Assert.True(Ok(5).Equals(Ok(5)));
        Assert.True(Ok(5).Equals((object)Ok(5)));
        Assert.True(Err<int>("Error").Equals(Err<int>("Error")));
    }

    [Fact]
    public void Equals_WhenResultsAreNotEqual_ShouldReturnFalse()
    {
        Assert.False(Ok(5).Equals(Ok(6)));
        Assert.False(Err<int>("Error").Equals(Err<int>("Error1")));
        Assert.False(Ok(5).Equals(Err<int>("Error")));
    }

    [Fact]
    public void EqualsOperator_WhenResultsAreEqual_ShouldReturnTrue()
    {
        Assert.True(Ok(5) == Ok(5));
        Assert.True(Err<int>("Error") == Err<int>("Error"));
    }

    [Fact]
    public void NotEqualsOperator_WhenResultsAreNotEqual_ShouldReturnTrue()
    {
        Assert.True(Ok(5) != Ok(6));
        Assert.True(Err<int>("Error") != Err<int>("Error1"));
        Assert.True(Ok(5) != Err<int>("Error"));
    }
}
