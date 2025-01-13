using Domain.Primitives;
using Xunit;
using static Domain.Primitives.OptionFactories;

namespace Domain.UnitTests.Primitives;

public class OptionTests
{
    [Fact]
    public void None_WhenCalled_ShouldReturnDefaultOption()
    {
        Assert.Equal("Nothing here", None<string>().Or("Nothing here"));
    }

    [Fact]
    public void Some_WhenCalledWithValue_ShouldCreateOptionWithValue()
    {
        Assert.Equal("Hello there", Some("Hello there").Or("Nothing here"));
    }

    [Fact]
    public void Equals_WhenOptionsAreEqual_ShouldReturnTrue()
    {
        Assert.True(Some("test").Equals(Some("test")));
        Assert.True(Some("test").Equals((object)Some("test")));
        Assert.True(None<string>().Equals(None<string>()));
    }

    [Fact]
    public void Equals_WhenOptionsAreNotEqual_ShouldReturnFalse()
    {
        Assert.False(Some("test1").Equals(Some("test2")));
        Assert.False(Some("test").Equals(None<string>()));
        Assert.False(None<string>().Equals(Some("test")));
    }

    [Fact]
    public void EqualsOperator_WhenOptionsAreEqual_ShouldReturnTrue()
    {
        Assert.True(Some("test") == Some("test"));
        Assert.True(None<string>() == None<string>());
    }

    [Fact]
    public void NotEqualsOperator_WhenOptionsAreNotEqual_ShouldReturnTrue()
    {
        Assert.True(Some("test1") != Some("test2"));
        Assert.True(Some("test") != None<string>());
    }

    [Fact]
    public void GetHashCode_WhenOptionsAreEqual_ShouldReturnSameValue()
    {
        Assert.Equal(Some("test").GetHashCode(), Some("test").GetHashCode());
        Assert.Equal(None<string>().GetHashCode(), None<string>().GetHashCode());
    }

    [Fact]
    public void Constructor_WhenValueIsNull_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Option<string>(null!));
    }
}
