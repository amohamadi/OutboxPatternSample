namespace Data.Entity;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public decimal Amount { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreateAt { get; set; }
    public virtual Order Order { get; set; }
}