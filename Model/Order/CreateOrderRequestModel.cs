namespace Model.Order;

public class CreateOrderRequestModel
{
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