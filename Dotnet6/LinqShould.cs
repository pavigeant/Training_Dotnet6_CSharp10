namespace Training_dotnet6_csharp10.Dotnet6;

public class LinqShould
{
    [Fact]
    public void GetByChunk()
    {
        var numbers = Enumerable.Range(1, 10);
        var chunked = numbers.Chunk(3);

        Assert.Equal(4, chunked.Count());
        Assert.Equal(3, chunked.First().Length);
        Assert.Single(chunked.Last());
    }

    [Fact]
    public void GetMaxByOrMinBy()
    {
        Person[] persons = {
            new("John", 20),
            new("Jane", 30),
            new("Doe", 40),
            new("Alice", 10),
            new("Bob", 50)
        };

        var oldest = persons.MaxBy(p => p.Age)!;
        var youngest = persons.MinBy(p => p.Age)!;

        Assert.Equal("Bob", oldest.Name);
        Assert.Equal("Alice", youngest.Name);
    }

    [Fact]
    public void GetDistinctBy()
    {
        Person[] persons =
        {
            new("John", 20),
            new("Jane", 30),
            new("Doe", 40),
            new("Alice", 10),
            new("Bob", 50),
            new("John", 25),
            new("Jane", 35),
            new("Doe", 45),
            new("Alice", 15),
            new("Bob", 55)
        };

        var distinct = persons.DistinctBy(p => p.Name).ToArray();

        Assert.Equal(5, distinct.Length);
        Assert.Equal("John", distinct[0].Name);
        Assert.Equal("Jane", distinct[1].Name);
        Assert.Equal("Doe", distinct[2].Name);
        Assert.Equal("Alice", distinct[3].Name);
        Assert.Equal("Bob", distinct[4].Name);

        // Also available are ExceptBy, IntersectBy and UnionBy
    }

    [Fact]
    public void AllowUsageOfDefaultValueInFirstOrDefault()
    {
        Person[] persons = Array.Empty<Person>();
        var defaultPerson = new Person("Default", 0);
        var person = persons.FirstOrDefault(p => p.Name == "John", defaultPerson);

        Assert.Equal(defaultPerson, person);

        // Also available in LastOrDefault and SingleOrDefault
    }

    [Fact]
    public void AllowRangeInTake()
    {
        var numbers = Enumerable.Range(1, 10).ToArray();

        var takes = numbers.Take(3..6);
        // instead of numbers.Skip(3).Take(3)
        // Effectively zero-based index

        Assert.Equal(new int[] { 4, 5, 6 }, takes);
    }

    [Fact]
    public void ZipThreeCollections()
    {
        var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        var letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
        var emoji = new string[] { "🤓", "🔥", "🎉", "👀", "⭐", "💜", "✔", "💯" };

        var zipped = numbers.Zip(letters, emoji);
        Assert.Equal(6, zipped.Count());
        Assert.Collection(zipped,
            z => Assert.Equal((1, 'A', "🤓"), z),
            z => Assert.Equal((2, 'B', "🔥"), z),
            z => Assert.Equal((3, 'C', "🎉"), z),
            z => Assert.Equal((4, 'D', "👀"), z),
            z => Assert.Equal((5, 'E', "⭐"), z),
            z => Assert.Equal((6, 'F', "💜"), z));
    }
}

public record Person(string Name, int Age);