using AutomapperLab.Models.OrderModels;

namespace AutomapperLab.Data
{
    public interface IOrderRepository
    {
        IList<OrderModel> GetOrders();
        IList<DealModel> GetDeals();
    }
}
