namespace Training_dotnet6_csharp10.Dotnet6;

public class PriorityQueueShould
{
    [Fact]
    public void SupportPriorityQueue()
    {
        var queue = new PriorityQueue<Operation, ProcessPriority>();
        queue.Enqueue(Operations.Add, ProcessPriority.Normal);
        queue.Enqueue(Operations.Multiply, ProcessPriority.Normal);
        queue.Enqueue(Operations.Subtract, ProcessPriority.High);

        var op = queue.Dequeue(); // substract is lowest priority value
        Assert.Equal(1, op(5, 4));
        op = queue.Dequeue(); // add is normal priority value, but was added first
        Assert.Equal(3, op(1, 2));
        op = queue.Dequeue(); // multiply is normal priority value, but was added second
        Assert.Equal(50, op(10, 5));
    }
}

public delegate float Operation(float left, float right);
public static class Operations
{
    public static float Add(float left, float right) => left + right;
    public static float Subtract(float left, float right) => left - right;
    public static float Multiply(float left, float right) => left * right;
}

public readonly record struct ProcessPriority(int Priority, string Name) : IComparable<ProcessPriority>
{
    // Requires IComparable implementation to be used as priority in PriorityQueue
    public int CompareTo(ProcessPriority other) => Priority.CompareTo(other.Priority);

    public static ProcessPriority High => new(1, nameof(High));
    public static ProcessPriority Normal => new(2, nameof(Normal));
}
