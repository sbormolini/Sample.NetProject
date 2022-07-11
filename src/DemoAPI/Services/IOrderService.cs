using DemoAPI.Data.Entities;

namespace DemoAPI.Services
{
    public interface IOrderService
    {
        Task<Order> Create(Order? order);
        Task<IEnumerable<Order>> GetAllItems();
        Task<Order?> GetById(Guid id);
        Task<bool> Update(Order? order);
        Task<bool> Remove(Guid id);
    }
}