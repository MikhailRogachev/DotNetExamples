using AutomapperLab.Data;
using Newtonsoft.Json.Linq;

namespace AutomapperLabTests.Data;

public class ContentSeedTests
{
    public static OrderContext Context()
    {
        var context = new OrderContext();
        OrderContextSeed.Seed(context);

        return context;
    }

    [Theory(), MemberData(nameof(GetOrderCase))]
    public void ContextOrder_Test(
        int orderId, 
        int linesNumber, 
        decimal totalAmount,
        decimal totalCost,
        decimal purchaseAmount)
    {
        var orders = Context().Order;

        Assert.NotNull(orders);
        Assert.Equal(2, orders.Count());

        var order = orders.First(p => p.Id == orderId);
        Assert.Equal(linesNumber, order.Lines.Count());

        decimal price = order.Lines.Sum(p => p.Price * p.Quantity);

        Assert.True(totalAmount == price,
            $"The Total Price expected: {totalAmount}, but found: {price}");

        decimal cost = order.Lines.Sum(p => p.Cost * p.Quantity);
        Assert.True(totalCost == cost, 
            $"The Total Coast expected: {totalCost}, but found: {cost}");

        decimal amount = 0;

        foreach(var line in order.Lines)
        {
            if (line.Deal?.StartDate <= order.CreatedDateTime
                && line.Deal?.EndDate >= order.CreatedDateTime)
            {
                var value = (line.Price * line.Quantity) * line.Deal.Percent / 100;
                amount += value;
            }
            else
            {
                var value = line.Price * line.Quantity;
                amount += value;
            }
        }

        Assert.True(purchaseAmount == amount, 
            $"The purchase amount expected: {purchaseAmount}, but found: {amount}");
    }

    /*
     * - order id
     * - expected number of lines
     * - expected total amount (price)
     * - expected cost total amount (cost)
     * - expected total amount include deals
     */
    public static TheoryData<int, int, decimal, decimal, decimal> GetOrderCase()
    {
        return new TheoryData<int, int, decimal, decimal, decimal>
        {
            {1, 2, 7890.0M, 6100.0M, 1183.5M },
            {2, 1, 1380.0M, 900.0M, 1380.0M }
        };
    }
}