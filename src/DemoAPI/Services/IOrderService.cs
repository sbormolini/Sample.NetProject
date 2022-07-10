using DemoAPI.Data.Entities;

namespace DemoAPI.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrder();
        Task<Order?> GetOrder(int id);
        Task PostOrder(Order order);
        Task DeleteOrder(Order order);
        bool IsOrderExists(int id);
        Task SaveChangesAsync();
    }
}