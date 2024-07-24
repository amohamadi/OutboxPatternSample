using Model.Common;

namespace Model.Event;

public class OrderCreatedEventModel : EventModel
{
    public long OrderId { get; set; }
    public int UserId { get; set; }
    public List<OrderItemModel> OrderItems { get; set; }
    public decimal Amount => OrderItems.Sum(x => x.TotalAmount);
    public class OrderItemModel 
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount => Amount * Count;
    }
}