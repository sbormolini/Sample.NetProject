using DemoAPI.Data;
using DemoAPI.Data.Entities;
using DemoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers;

[ApiController, Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    //private readonly OrderDbContext _ordersDbContext;
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService) => _orderService = orderService;

    //GET: api/Orders  
    /// <summary>  
    /// Gets the order.  
    /// </summary>  
    /// <returns>Task<ActionResult<IEnumerable<Order>>>.</returns>  
    [HttpGet]
    public async Task<IActionResult> GetOrder()
    {
        return Ok(await _orderService.GetAllOrder());
    }

    // GET: api/Orders/5  
    /// <summary>  
    /// Gets the order.  
    /// </summary>  
    /// <param name="id">The identifier.</param>  
    /// <returns>Task<ActionResult<Order>>.</returns>  
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _orderService.GetOrder(id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    //// PUT: api/Orders/5  
    ///// <summary>  
    ///// Puts the order.  
    ///// </summary>  
    ///// <param name="id">The identifier.</param>  
    ///// <param name="order">The order.</param>  
    ///// <returns>Task<IActionResult>.</returns>  
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutOrder(int id, Order order)
    //{
    //    if (id != order.OrderId)
    //    {
    //        return BadRequest();
    //    }

    //    _ordersDbContext.Entry(order).State = EntityState.Modified;

    //    try
    //    {
    //        await _orderService.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!IsOrderExists(id))
    //        {
    //            return NotFound();
    //        }

    //        throw;
    //    }

    //    return NoContent();
    //}

    // POST: api/Orders  
    /// <summary>  
    /// Posts the order.  
    /// </summary>  
    /// <param name="order">The order.</param>  
    /// <returns>Task<ActionResult<Order>>.</returns>  
    [HttpPost]
    public async Task<IActionResult> PostOrder(Order order)
    {
        //_ordersDbContext.Orders.Add(order);
        //await _ordersDbContext.SaveChangesAsync();
        await _orderService.PostOrder(order);
        return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
    }

    // DELETE: api/Orders/5  
    /// <summary>  
    /// Deletes the order.  
    /// </summary>  
    /// <param name="id">The identifier.</param>  
    /// <returns>Task<ActionResult<Order>>.</returns>  
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _orderService.GetOrder(id);
        if (order == null)
        {
            return NotFound();
        }

        await _orderService.DeleteOrder(order);

        return Ok(order);
    }

    /// <summary>  
    /// Determines whether [is order exists] [the specified identifier].  
    /// </summary>  
    /// <param name="id">The identifier.</param>  
    /// <returns><c>true</c> if [is order exists] [the specified identifier]; otherwise, <c>false</c>.</returns>  
    private bool IsOrderExists(int id) => _orderService.IsOrderExists(id);
}