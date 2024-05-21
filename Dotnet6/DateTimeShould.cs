using System.Text.Json;

namespace Training_dotnet6_csharp10.Dotnet6;

public class DateTimeShould
{
    [Fact]
    public void SupportDateOnly()
    {
        var date = new DateOnly(2021, 10, 10);
        Assert.Equal(2021, date.Year);
        Assert.Equal(10, date.Month);
        Assert.Equal(10, date.Day);
    }

    [Fact]
    public void SupportTimeOnly()
    {
        var time = new TimeOnly(10, 30);
        Assert.Equal(10, time.Hour);
        Assert.Equal(30, time.Minute);
    }

    [Fact]
    public void DoesNotSerializeByDefault()
    {
        var date = new DateOnly(2021, 10, 10);
        var time = new TimeOnly(10, 30);

        // Serialization for DateOnly and TimeOnly is available in .net 7
        Assert.Throws<NotSupportedException>(() => JsonSerializer.Serialize(date));
        Assert.Throws<NotSupportedException>(() => JsonSerializer.Serialize(time));
    }
}
