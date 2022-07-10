using DemoAPI.Data;
using DemoAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _context;
    public OrderService(OrderDbContext context) => _context = context;

    //public async Task<List<Order>> GetAllAsync()
    //{
    //    return await _context.Orders.ToListAsync();
    //}
    //public async Task SaveAsync(Order newTodo)
    //{
    //    _context.Orders.Add(newTodo);
    //    await _context.SaveChangesAsync();
    //}

    public async Task<List<Order>> GetAllOrder()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order?> GetOrder(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task PutOrder(int id, Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task PostOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public bool IsOrderExists(int id) => _context.Orders.Any(e => e.OrderId == id);
}
