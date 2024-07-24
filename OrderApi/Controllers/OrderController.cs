using Data;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Model.Order;
using Service.Contract;

namespace OrderApi.Controllers;

public class OrderController(IOrderService orderService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequestModel requestModel, CancellationToken cancellationToken = default)
    {
        return Ok(await orderService.CreateAsync(requestModel, cancellationToken));
    }
}