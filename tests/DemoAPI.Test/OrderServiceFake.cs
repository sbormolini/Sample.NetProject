using DemoAPI.Data.Entities;
using DemoAPI.Services;
using System.Collections.ObjectModel;

namespace DemoAPI.Test;

internal class OrderServiceFake : IOrderService
{
    private readonly List<Order> _orders;

    public OrderServiceFake()
    {
        _orders = new List<Order>()
        {
            new Order() {
                OrderId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Name = "Amazon Order",
                ProductIds = new Collection<Guid>() {
                    new Guid("c9efd607-9dd1-40f5-853a-7ba819df481f"),
                    new Guid("ce99116c-fa6e-45d2-8b54-f8834db4abca")
                }
            },
            new Order() {
                OrderId = new Guid("1bd1800d-e024-4957-bd28-b0e59d830a5a"),
                Name = "Ebay Order",
                ProductIds = new Collection<Guid>() {
                    new Guid("f21d9594-11d8-4d02-b84e-8379f45a794f"),
                    new Guid("0eba7e37-b715-4d4d-a14b-1b4e48228a34"),
                    new Guid("b1f2b958-d838-4d35-8197-18a02a64e131")
                }
            }
        };
    }

    public async Task<Order> Create(Order? order)
    {
        _orders.Add(order);
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllItems() => _orders;

    public async Task<Order?> GetById(Guid id) => _orders.Where(x => x.OrderId == id).FirstOrDefault();

    public async Task<bool> Remove(Guid id)
    {
        var existing = _orders.First(x => x.OrderId == id);
        _orders.Remove(existing);
        return true;
    }

    public Task<bool> Update(Order? order)
    {
        throw new NotImplementedException();
    }
}
