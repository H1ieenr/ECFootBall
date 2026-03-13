using ECFootball.Order.API.Dtos.CartDto;
using ECFootball.Order.API.Helpers.Utilities;

namespace ECFootball.Order.API._Service.Interface
{
    public interface ICartService 
    {
        Task<OperationResult> AddToCartAsync(AddToCartDto dto);
        Task<OperationResult> SyncCartAsync(string userId, List<CartItemDto> anonymousItems);
        Task<CartDto> GetCartAsync(string userId);
        Task<OperationResult> RemoveFromCartAsync(string userId, string productId);
        Task<OperationResult> ClearCartAsync(string userId);
    }
}
