namespace Data;

public class BaseEntity<T>
{
    public T Id { get; set; }
}

public class BaseEntity : BaseEntity<int>
{
}