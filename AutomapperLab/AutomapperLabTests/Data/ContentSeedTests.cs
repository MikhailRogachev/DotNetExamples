using AutomapperLab.Data;

namespace AutomapperLabTests.Data;

public class ContentSeedTests
{
    [Fact]
    public void Seed_Test()
    {
        var content = new OrderContext();
        OrderContextSeed.ContentIni(content);

        Assert.NotNull(content);

        var order = content.Order.FirstOrDefault();
        Assert.NotNull(order);
        Assert.NotNull(order?.Customer);
    }
}
