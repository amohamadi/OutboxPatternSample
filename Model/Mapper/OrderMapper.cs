using Model.Event;
using Model.Order;

namespace Model.Mapper;

public static class OrderMapper
{
    public static OrderCreatedEventModel MapToEventModel(this CreateOrderRequestModel input, int orderId)
    {
        return new OrderCreatedEventModel()
        {
            UserId = input.UserId,
            CreateAt = DateTime.Now,
            OrderId = orderId,
            OrderItems = input.OrderItems.Select(x => new OrderCreatedEventModel.OrderItemModel
            {
                ProductId = x.ProductId,
                Count = x.Count,
                Amount = x.Amount
            }).ToList(),
        };
    }
}