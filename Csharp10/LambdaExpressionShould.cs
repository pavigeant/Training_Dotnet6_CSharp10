using System.Diagnostics.CodeAnalysis;

namespace Training_dotnet6_csharp10.Csharp10;

public class LambdaExpressionShould
{
    [Fact]
    public void InfersParameterType()
    {
        // Before C# 10
        //Func<int, int> square = x => x * x;
        var square = (int x) => x * x;

        Assert.Equal(25, square(5));
    }

    [Fact]
    public void InfersReturnType()
    {
        // Before C# 10
        //var choose = (bool b) => b ? 1 : "two"; // ERROR: Can't infer return type
        var choose = object (bool b) => b ? 1 : "two";

        Assert.Equal(1, choose(true));
        Assert.Equal("two", choose(false));
    }

    [Fact]
    public void SupportAttributes()
    {
        var concat = ([DisallowNull] string a, [DisallowNull] string b) => a + b;
        var increment = [return: NotNullIfNotNull(nameof(s))] int? (int? s) => s.HasValue ? s.Value + 1 : null;

        Assert.Equal("Hello, World!", concat("Hello, ", "World!"));
        Assert.Equal(6, increment(5));
    }
}