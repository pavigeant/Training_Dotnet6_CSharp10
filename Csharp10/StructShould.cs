namespace Training_dotnet6_csharp10.Csharp10;

public class StructShould
{
    [Fact]
    public void SupporttAnonymousTypeForWithExpression()
    {
        var point = new { X = 1, Y = 2 };
        var point2 = point with { X = 3 };

        Assert.Equal(3, point2.X);
    }

    [Fact]
    public void InitializeStructWithDefaultValues()
    {
        var measurement1 = new Measurement();
        Assert.Equal(double.NaN, measurement1.Value);

        var measurement2 = default(Measurement);
        Assert.Equal(0.0d, measurement2.Value);

        var measurements = new Measurement[2];
        Assert.Equal("0, 0", string.Join(", ", measurements));
    }
}

public readonly struct Measurement
{
    public Measurement()
    {
        Value = double.NaN;
    }

    public double Value { get; init; }

    public override string ToString() => Value.ToString();
}