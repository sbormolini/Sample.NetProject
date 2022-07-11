using DemoAPI.Data;
using DemoAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _context;
    public OrderService(OrderDbContext context) => _context = context;

    public async Task<Order> Create(Order? order)
    {
        if (order is null)
            throw new ArgumentNullException(nameof(order));

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllItems() => await _context.Orders.ToListAsync();
  
    public async Task<Order?> GetById(Guid id) => await _context.Orders.FindAsync(id);


    public Task<bool> Update(Order? order)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Remove(Guid id)
    {
        var existingOrder = await GetById(id);
        if (existingOrder is null)
            return false;

        _context.Orders.Remove(existingOrder);
        await _context.SaveChangesAsync();

        return true;
    }
}
