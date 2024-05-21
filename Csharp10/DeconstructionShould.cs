namespace Training_dotnet6_csharp10.Csharp10;

public class DeconstructionShould
{
    [Fact]
    public void SupportAssignmentAndDeclarationInSameDeconstruction()
    {
        int x = 10;

        (x, int y) = (20, 30);

        Assert.Equal(20, x);
        Assert.Equal(30, y);
    }
}