using ECFootball.Order.API.Dtos.ProductDto;

namespace ECFootball.Order.API._Service.Interface
{
    public interface IProductClient
    {
        Task<ProductDto?> GetProductByIdAsync(string productId);
    }
}
