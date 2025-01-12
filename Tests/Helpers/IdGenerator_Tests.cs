using Business.Helpers;

namespace Tests.Helpers;

public class IdGenerator_Tests
{
    [Fact]
    public void Generate_ShouldReturnGuidAsString()
    {
        // Act 
        var result = IdGenerator.Generate();
        
        // Assert 
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}