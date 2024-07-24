namespace Data.Entity;

public class Event : BaseEntity
{
    public string Type { get; set; }
    public string JsonBody { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? PublishAt { get; set; }
    public bool IsPublish { get; set; }
}