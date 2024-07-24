namespace Data.Entity;

public class Order:BaseEntity
{
    public DateTime CreateAt { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
