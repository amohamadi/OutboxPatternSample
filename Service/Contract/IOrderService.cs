using Model.Common;
using Model.Order;

namespace Service.Contract;

public interface IOrderService
{
    Task<BaseResponse> CreateAsync(CreateOrderRequestModel requestModel, CancellationToken cancellationToken = default);
}