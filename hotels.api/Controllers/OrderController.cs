
using System.Collections.Generic;
using AutoMapper;
using hotels.api.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/orders")]
public class OrderController : Controller
{
    private readonly IOrderQueryHandler ordersQueryHandler;
    private readonly IMapper mapper;

    public OrderController(IOrderQueryHandler ordersQueryHandler, IMapper mapper)
    {
        this.ordersQueryHandler = ordersQueryHandler;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var response = new List<OrderResponse>();
        var orders = ordersQueryHandler.GetOrders();
        if(orders != null){
            response = mapper.Map<List<OrderData>, List<OrderResponse>>(orders);
        }
        return Ok(response);
    }


}