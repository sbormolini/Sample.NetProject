using DemoAPI.Controllers;
using DemoAPI.Data.Entities;
using DemoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DemoAPI.Test;

public class OrdersControllerTest
{
    private readonly OrdersController _controller;
    private readonly IOrderService _service;

    public OrdersControllerTest()
    {
        _service = new OrderServiceFake();
        _controller = new OrdersController(_service);
    }

    [Fact]
    public async void GetAll_WhenCalled_ReturnsOkResult()
    {
        // Act
        var okResult = await _controller.GetAll();

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public async void Get_WhenCalled_ReturnsAllItems()
    {
        // Act
        var okResult = await _controller.GetAll() as OkObjectResult;

        // Assert
        var items = Assert.IsType<List<Order>>(okResult.Value);
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public async void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        // Act
        var id = new Guid("13d88deb-2f20-4187-ab2f-9a4e6191ab09");
        var notFoundResult = await _controller.Get(id);

        // Assert
        Assert.IsType<NotFoundResult>(notFoundResult);
    }
}