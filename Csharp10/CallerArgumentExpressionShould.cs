using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Training_dotnet6_csharp10.Csharp10;

public class CallerArgumentExpressionShould
{
    [Fact]
    public void SupportCallerArgumentExpression()
    {
        static void ValidateArgument(string parameterName, [DoesNotReturnIf(false)] bool condition, [CallerArgumentExpression("condition")] string? message = null)
        {
            if (!condition)
            {
                throw new ArgumentException($"Argument failed validation: <{message}>", parameterName);
            }
        }

        static void Operation(Action? func)
        {
            ValidateArgument(nameof(func), func is not null);

            // Does not raise a warning because of DoesNotReturnIf
            func();
        }

        var exception = Assert.Throws<ArgumentException>(() => Operation(null));
        Assert.Equal("Argument failed validation: <func is not null> (Parameter 'func')", exception.Message);


        var noException = Record.Exception(() => Operation(() => { }));
        Assert.Null(noException);
    }
}