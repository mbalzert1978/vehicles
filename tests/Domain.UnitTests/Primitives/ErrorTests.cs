namespace Domain.UnitTests.Primitives;

using Domain.Primitives;

public class ErrorTests
{
    [Fact]
    public void Error_WhenCreatedWithEmptyCodeAndNonEmptyDescription_ShouldHaveCorrectProperties()
    {
        string code = string.Empty;
        string description = "Test Description";

        Error error = new(code, description);

        Assert.Equal(code, error.Code);
        Assert.Equal(description, error.Description);
    }

    [Fact]
    public void Error_WhenCreatedWithEmptyCodeAndNullDescription_ShouldHaveCorrectProperties()
    {
        string code = string.Empty;
        string? description = null;

        Error error = new(code, description);

        Assert.Equal(code, error.Code);
        Assert.Null(error.Description);
    }

    [Fact]
    public void Error_WhenCreatedWithNonEmptyCodeAndNonEmptyDescription_ShouldHaveCorrectProperties()
    {
        string code = "Test Code";
        string description = "Test Description";

        Error error = new(code, description);

        Assert.Equal(code, error.Code);
        Assert.Equal(description, error.Description);
    }

    [Fact]
    public void Error_WhenCreatedWithNonEmptyCodeAndNullDescription_ShouldHaveCorrectProperties()
    {
        string code = "Test Code";
        string? description = null;

        Error error = new(code, description);

        Assert.Equal(code, error.Code);
        Assert.Null(error.Description);
    }

    [Fact]
    public void Error_WhenUsingNoneProperty_ShouldHaveEmptyCodeAndDescription()
    {
        string expectedCode = string.Empty;
        string expectedDescription = string.Empty;

        Error error = Error.None;

        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedDescription, error.Description);
    }
}
