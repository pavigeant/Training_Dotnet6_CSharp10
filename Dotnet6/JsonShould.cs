using System.Text.Json;
using System.Text.Json.Nodes;

namespace Training_dotnet6_csharp10.Dotnet6;

public class JsonShould
{
    [Fact]
    public void SupportWrittableDOM()
    {
        var node = JsonNode.Parse("{\"name\": \"dotnet\"}")!;
        node["name"] = "dotnet6";

        Assert.Equal("dotnet6", node["name"]!.ToString());
    }

    [Fact]
    public void SupportObjectInitializer()
    {
        var node = new JsonObject
        {
            ["name"] = "dotnet"
        };

        node["name"] = "dotnet6";

        Assert.Equal("dotnet6", node["name"]!.ToString());
    }

    [Fact]
    public void AllowDeserializingSubSection()
    {
        var json = "{\"name\": \"dotnet\", \"settings\": { \"version\": 6 }}";

        var node = JsonNode.Parse(json)!;
        var settingsObject = node["settings"]!.AsObject();

        var settings = settingsObject.Deserialize<Settings>(new JsonSerializerOptions(JsonSerializerDefaults.Web))!;

        Assert.Equal(6, settings.Version);
    }
}

public class Settings
{
    public int Version { get; set; }
}