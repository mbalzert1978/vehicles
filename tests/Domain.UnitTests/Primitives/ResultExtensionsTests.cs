using Domain.Primitives;
using static Domain.Primitives.OptionFactories;
using static Domain.Primitives.ResultFactories;

namespace Domain.UnitTests.Primitives;

public class ResultExtensionsTests
{
    private static int Count(string s) => s.Length;

    private static Result<string, string> SqThenToString(int x)
    {
        try
        {
            return Ok(checked(x * x).ToString());
        }
        catch (OverflowException)
        {
            return Err<string>("Overflowed");
        }
    }

    [Fact]
    public void IsOk_WhenResultIsOk_ShouldReturnTrue()
    {
        Assert.True(Ok(10).IsOk());
        Assert.False(Err<int>("Something went wrong").IsOk());
    }

    [Fact]
    public void IsErr_WhenResultIsErr_ShouldReturnTrue()
    {
        Assert.False(Ok(-3).IsErr());
        Assert.True(Err<int>("Something went wrong").IsErr());
    }

    [Fact]
    public void Ok_WhenResultIsOk_ShouldReturnValue()
    {
        Assert.Equal(Some(10), Ok(10).Ok());
        Assert.Equal(None<int>(), Err<int>("Something went wrong").Ok());
    }

    [Fact]
    public void UnwrapOrDefault_WhenResultIsOk_ShouldReturnValue()
    {
        Assert.Equal(2, Ok(2).UnwrapOrDefault());
        Assert.Equal(default, Err<int>("Nothing here").UnwrapOrDefault());
    }

    [Fact]
    public void UnwrapOrDefault_WhenResultIsErr_ShouldReturnDefault()
    {
        Assert.Equal(2, Ok(2).UnwrapOrDefault());
        Assert.Equal(default, Err<int>("Nothing here").UnwrapOrDefault());
    }

    [Fact]
    public void Filter_WhenResultIsOk_ShouldApplyFunctionToValue()
    {
        Assert.Equal(Ok(5).Filter(i => i > 2), Some(5));
        Assert.Equal(Ok(5).Filter(i => i > 10), None<int>());
        Assert.Equal(Err<int>("Nothing here").Filter(i => i > 2), None<int>());
    }

    [Fact]
    public void Map_WhenResultIsOk_ShouldApplyFunctionToValue()
    {
        Assert.Equal(Ok(5).Map(i => i * 2).Map(SqThenToString), Ok("100"));
        Assert.Equal(Ok(1_000_000).Map(SqThenToString), Err<string, string>("Overflowed"));
    }

    [Fact]
    public void MapErr_WhenResultIsErr_ShouldApplyFunctionToError()
    {
        Assert.Equal(Ok<int, int>(5).MapErr(i => i.ToString()), Ok(5));
        Assert.Equal(Err<int, int>(10).MapErr(i => i.ToString()), Err<int>("10"));
    }

    [Fact]
    public void Iter_WhenResultIsOk_ShouldYieldValue()
    {
        Assert.Equal(5, Ok(5).Iter().First());
        Assert.Empty(Err<int>("Nothing here").Iter());
    }

    [Fact]
    public void UnwrapOr_WhenResultIsOk_ShouldReturnValue()
    {
        Assert.Equal(2, Ok(2).UnwrapOr(42));
        Assert.Equal(42, Err<int>("Something went wrong").UnwrapOr(42));
    }

    [Fact]
    public void UnwrapOrElse_WhenResultIsOk_ShouldReturnValue()
    {
        Assert.Equal(2, Ok(2).UnwrapOrElse(Count));
        Assert.Equal(3, Err<int>("foo").UnwrapOrElse(Count));
    }
}
