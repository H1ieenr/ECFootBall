using ECFootball.Order.API.Dtos.OrderDto;
using ECFootball.Order.API.Helpers.Utilities;

namespace ECFootball.Order.API._Service.Interface
{
    public interface IOrderService
    {
        Task<OperationResult> CheckoutAsync(CheckoutDto dto);
        Task<OrderDto> GetOrderDetailAsync(string orderCode);
    }
}
