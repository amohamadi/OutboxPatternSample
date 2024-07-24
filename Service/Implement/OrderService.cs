using Data;
using Data.Entity;
using Model.Common;
using Model.Event;
using Model.Mapper;
using Model.Order;
using Service.Contract;

namespace Service.Implement;

public class OrderService(AppDbContext dbContext, IEventService eventService) : IOrderService
{
    public async Task<BaseResponse> CreateAsync(CreateOrderRequestModel requestModel, CancellationToken cancellationToken = default)
    {
        var result = new BaseResponse();

        var order = new Order()
        {
            CreateAt = DateTime.Now,
            UserId = requestModel.UserId,
            Amount = requestModel.Amount,
            OrderItems = requestModel.OrderItems.Select(x => new OrderItem()
            {
                CreateAt = DateTime.Now,
                ProductId = x.ProductId,
                Count = x.Count,
                Amount = x.Amount,
                TotalAmount = x.TotalAmount,
            }).ToList()
        };

        await dbContext.Orders.AddAsync(order, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        await eventService.AddAsync(requestModel.MapToEventModel(order.Id), cancellationToken);

        return result.Success();
    }
}