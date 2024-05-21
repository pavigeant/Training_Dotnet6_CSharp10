namespace Training_dotnet6_csharp10.Csharp10;

public class RecordShould
{
    [Fact]
    public void RecordClassAreReferenceTypes()
    {
        var record1 = new RecordClassImplicit(1, "Record");
        var record2 = new RecordClassExplicit(2, "Record");

        static void ChangeRecordImplicit(RecordClassImplicit record) { record.MutableValue = "Changed"; }
        static void ChangeRecordExplicit(RecordClassExplicit record) { record.MutableValue = "Changed"; }

        ChangeRecordImplicit(record1);
        ChangeRecordExplicit(record2);

        Assert.Equal("Changed", record1.MutableValue);
        Assert.Equal("Changed", record2.MutableValue);
    }

    [Fact]
    public void RecordClassAreImmutable()
    {
        var record = new RecordClassImplicit(1, "Record");

        // Cannot change the name as record class are immutable
        // record.Name = "Changed";
    }

    [Fact]
    public void RecordStructOverridesEqualityOperator()
    {
        var vector1 = new Vector3(1, 2, 3);
        var vector2 = new Vector3(1, 2, 3);
        var vector3 = new Vector3(1, 2, 4);

        Assert.True(vector1 == vector2);
        Assert.True(vector1 != vector3);

        var vectorStruct1 = new Vector3Struct(1, 2, 4);
        var vectorStruct2 = new Vector3Struct(1, 2, 4);

        // Assert.True(vectorStruct1 == vectorStruct2);
    }

    [Fact]
    public void RecordStructsAreOddlyMutable()
    {
        var record = new Vector3(1, 2, 3);

        record.X++;

        Assert.Equal(2, record.X);
    }

    [Fact]
    public void ReadonlyRecordStructsAreImmutable()
    {
        var record = new Vector3Readonly(1, 2, 3);

        // Cannot change the value as readonly record struct are immutable
        // record.X++;

        Assert.Equal(1, record.X);
    }

    [Fact]
    public void SupportDeconstructing()
    {
        var record1 = new RecordClassImplicit(1, "Record");
        var record2 = new RecordClassExplicit(2, "Record");
        var vector1 = new Vector3(1, 2, 3);
        var vector2 = new Vector3Readonly(1, 2, 3);

        var (id1, name1) = record1;
        var (id2, name2) = record2;
        var (x1, y1, z1) = vector1;
        var (x2, y2, z2) = vector2;

        Assert.Equal(1, id1);
        Assert.Equal("Record", name1);
        Assert.Equal(2, id2);
        Assert.Equal("Record", name2);
        Assert.Equal(1, x1);
        Assert.Equal(2, y1);
        Assert.Equal(3, z1);
        Assert.Equal(1, x2);
        Assert.Equal(2, y2);
        Assert.Equal(3, z2);
    }

    [Fact]
    public void SupportToString()
    {
        var record1 = new RecordClassImplicit(1, "Record");
        var record2 = new RecordClassExplicit(2, "Record");
        var vector1 = new Vector3(1, 2, 3);
        var vector2 = new Vector3Readonly(1, 2, 3);

        Assert.Equal("RecordClassImplicit { Id = 1, Name = Record, MutableValue =  }", record1.ToString());
        Assert.Equal("RecordClassExplicit { Id = 2, Name = Record, MutableValue =  }", record2.ToString());
        Assert.Equal("Vector3 { X = 1, Y = 2, Z = 3 }", vector1.ToString());
        Assert.Equal("Vector3Readonly { X = 1, Y = 2, Z = 3 }", vector2.ToString());
    }
}

public record RecordClassImplicit(int Id, string Name)
{
    public string? MutableValue { get; set; }
}

public record class RecordClassExplicit(int Id, string Name)
{
    public string? MutableValue { get; set; }
}

public record struct Vector3(float X, float Y, float Z);

public struct Vector3Struct
{
    public Vector3Struct(float x, float y, float z) => (X, Y, Z) = (x, y, z);

    public float X;
    public float Y;
    public float Z;
}

public readonly record struct Vector3Readonly(float X, float Y, float Z);

public record Person(string FirstName, string LastName)
{
    public sealed override string ToString() => $"{FirstName} {LastName}";
}

public record Teacher(string FirstName, string LastName) : Person(FirstName, LastName)
{
    // Cannot override ToString as it is sealed
    // public override string ToString() => $"Teacher: {FirstName} {LastName}";
}