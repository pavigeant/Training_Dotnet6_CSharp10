using System.Net.Sockets;

namespace Training_dotnet6_csharp10.Csharp10;

public class ExtendedPropertyPatternsShould
{
    [Fact]
    public void AcceptExtendedPropertyPatterns()
    {
        var employee = new Employee(1, "John", new Address("Street", "City", "Country"));

        // Before C# 10
        // Assert.True(employee is { Address: { City: "City" } });
        
        Assert.True(employee is { Address.City: "City" });
    }
}

public record Employee(int Id, string Name, Address Address);

public record Address(string Street, string City, string Country);