namespace Model.Common;

public class BaseResponse<T> : BaseResponse
{
    public BaseResponse Success(T data)
    {
        data = Data;
        IsSuccess = true;
        return this;
    }
    
    public T Data { get; set; }
}

public class BaseResponse
{
    public BaseResponse Success()
    {
        IsSuccess = true;
        return this;
    }
    
    public BaseResponse Failed()
    {
        IsSuccess = false;
        return this;
    }
    
    public BaseResponse Failed(string message)
    {
        IsSuccess = false;
        Message = message;
        return this;
    }
    
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}

