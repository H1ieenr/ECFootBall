using ECFootBall.Dtos.ProductDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootBall._Service.Interfaces
{
    public interface IProductService
    {
        Task<PaginationUtility<ProductDto>> GetListProduct(PaginationParam pagination, SearchProductDto dto, bool isPaging = true);
        Task<ProductDto> GetProduct(string ProductId);
        Task<OperationResult> Create(CreateProductDto dto);
        Task<OperationResult> Update(UpdateProductDto dto);
        Task<OperationResult> Delete(string ProductId);
    }
}
