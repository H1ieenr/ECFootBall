using ECFootball.Product.API.Dtos.ProductDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootball.Product.API._Service.Interfaces
{
    public interface IProductService
    {
        Task<PaginationUtility<ProductDto>> GetPagedProductsAsync(PaginationParam pagination, SearchProductDto dto, bool isPaging = true);
        Task<ProductDto> GetProductByIdAsync(string ProductId);
        Task<OperationResult> Create(CreateProductDto dto);
        Task<OperationResult> Update(UpdateProductDto dto);
        Task<OperationResult> Delete(string productId, string deletedBy);
    }
}
