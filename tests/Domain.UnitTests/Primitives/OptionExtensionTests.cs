namespace Domain.UnitTests.Primitives;

using Domain.Primitives;
using static Domain.Primitives.OptionFactories;

public class OptionExtensionTests
{
    public static Option<int> Square(int value)
    {
        try
        {
            return Some(checked(value * value));
        }
        catch (Exception)
        {
            return None<int>();
        }
    }

    [Fact]
    public void IsSome_WhenOptionIsSome_ShouldReturnTrue() => Assert.True(Some("test").IsSome());

    [Fact]
    public void IsSome_WhenOptionIsNone_ShouldReturnFalse() =>
        Assert.False(None<string>().IsSome());

    [Fact]
    public void IsNone_WhenOptionIsSome_ShouldReturnFalse() => Assert.False(Some("test").IsNone());

    [Fact]
    public void IsNone_WhenOptionIsNone_ShouldReturnTrue() => Assert.True(None<string>().IsNone());

    [Fact]
    public void Map_WhenOptionIsSome_ShouldReturnMappedValue() =>
        Assert.Equal("Hello there", Some("there").Map(s => "Hello " + s).Or("Nothing here"));

    [Fact]
    public void Map_WhenOptionIsNone_ShouldReturnDefault() =>
        Assert.Equal("Nothing here", None<string>().Map(s => "Hello " + s).Or("Nothing here"));

    [Fact]
    public void Or_WhenOptionIsSome_ShouldReturnValue() =>
        Assert.Equal("Hello there", Some("Hello there").Or("Nothing here"));

    [Fact]
    public void Or_WhenOptionIsSomeAndGivenDefaultFunction_ShouldIgnoreDefaultFunction() =>
        Assert.Equal("Hello there", Some("Hello there").Or(() => "Nothing here"));

    [Fact]
    public void Or_WhenOptionIsNone_ShouldReturnDefault() =>
        Assert.Equal("Nothing here", None<string>().Or("Nothing here"));

    [Fact]
    public void Or_WhenOptionIsNoneAndGivenDefaultFunction_ShouldComputeDefaultFunction() =>
        Assert.Equal("Default value", None<string>().Or(() => "Default value"));

    [Fact]
    public void Map_WhenGivenFunctionThatReturnsOptionAndInputIsValid_ShouldReturnMappedValue() =>
        Assert.Equal(Some(100), Some(10).Map(Square));

    [Fact]
    public void Map_WhenGivenFunctionThatReturnsOptionAndInputIsInvalid_ShouldReturnNone() =>
        Assert.Equal(None<int>(), Some(1_000_000).Map(Square));
}
