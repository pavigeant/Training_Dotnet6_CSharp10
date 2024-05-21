using System.Text.Json;
using System.Text.Json.Serialization;

namespace Training_dotnet6_csharp10.Dotnet6;

public class JsonSourceGeneratorShould 
{
    [Fact]
    public void SerializeUsingSourceGenerator()
    {
        var weatherForecast = new WeatherForecast
        {
            Date = DateTime.Now,
            TemperatureCelsius = 25,
            Summary = "Hot"
        };

        var json = JsonSerializer.Serialize(weatherForecast, SourceGenerationContext.Default.WeatherForecast);
        var deserialized = JsonSerializer.Deserialize(json, SourceGenerationContext.Default.WeatherForecast)!;

        Assert.Equal(weatherForecast.Date, deserialized.Date);
        Assert.Equal(weatherForecast.TemperatureCelsius, deserialized.TemperatureCelsius);
        Assert.Equal(weatherForecast.Summary, deserialized.Summary);
    }
}

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
}

[JsonSourceGenerationOptions(
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(WeatherForecast))]
public partial class SourceGenerationContext : JsonSerializerContext
{
}