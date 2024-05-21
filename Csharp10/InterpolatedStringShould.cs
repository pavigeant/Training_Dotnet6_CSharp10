using System.Runtime.CompilerServices;

namespace Training_dotnet6_csharp10.Csharp10;

public class InterpolatedStringShould
{
    [Fact]
    public void SupportConstantInterpolatedString()
    {
        const string version = "10";
        // All values in the interpolated string must be STRING constant
        const string csharp = $"C# {version}";

        Assert.Equal("C# 10", csharp);
    }

    [Fact]
    public void SupportCustomInterpolatedStringHandler()
    {
        static string PrepareData(CustomInterpolatedString value) => $"Preparing {value.GetFormattedText()}";
        static string PrepareData2(
            // Prefix is passed to the handler extra arguments by position
            string prefix, 
            [InterpolatedStringHandlerArgument("prefix")] CustomInterpolatedString value) => 
            $"Preparing {value.GetFormattedText()}";

        var data = PrepareData($"Hello {10} World {20}");
        var data2 = PrepareData2("test", $"Hello {10} World {20}");

        Assert.Equal("Preparing Hello arg(10) World arg(20)", data);
        Assert.Equal("Preparing Hello test(10) World test(20)", data2);
    }
}

[InterpolatedStringHandler]
public class CustomInterpolatedString
{
    private readonly string _formattedPrefix;
    private readonly StringBuilder _builder;

    public CustomInterpolatedString(int literalLength, int formattedCount)
    {
        _builder = new StringBuilder(literalLength);
        _formattedPrefix = "arg";
    }

    public CustomInterpolatedString(int literalLength, int formattedCount, string formattedPrefix)
    {
        _builder = new StringBuilder(literalLength);
        _formattedPrefix = formattedPrefix;
    }

    public void AppendLiteral(string s) => _builder.Append(s);

    public void AppendFormatted<T>(T t) => _builder.Append($"{_formattedPrefix}({t})");

    internal string GetFormattedText() => _builder.ToString();
}
