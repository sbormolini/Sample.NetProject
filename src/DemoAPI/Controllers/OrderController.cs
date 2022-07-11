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
    private readonly IOrderService _orderService;
    public OrdersController(IOrderService orderService) => _orderService = orderService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _orderService.GetAllItems();
        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var order = await _orderService.GetById(id);
        if (order is null)
            return NotFound();
       
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Order order)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var createdOrder = await _orderService.Create(order);
        return CreatedAtAction("Get", new { id = createdOrder.OrderId }, createdOrder);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Order updatedOrder)
    {
        var order = _orderService.GetById(id);
        if (order is null)
            return NotFound();

        await _orderService.Update(updatedOrder);
        return Ok(updatedOrder);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var existingOrder = await _orderService.GetById(id);
        if (existingOrder == null)
            return NotFound();
        
        await _orderService.Remove(id);
        return Ok();
    }
}