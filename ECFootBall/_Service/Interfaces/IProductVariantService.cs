using ECFootball.Product.API.Dtos.ProductVariantDto;
using ECFootBall.Dtos.ProductVariantDto;
using ECFootBall.Helpers.Utilities;
using System.Collections.Generic;

namespace ECFootball.Product.API._Service.Interfaces
{
    public interface IProductVariantService
    {
        Task<PaginationUtility<ProductVariantDto>> GetPagedProductVariantsAsync(PaginationParam pagination, SearchProductVariantDto dto, bool isPaging = true);
        Task<ProductVariantDto> GetProductVariantByIdAsync(int productVariantId);
        Task<OperationResult> Create(CreateProductVariantDto dto);
        Task<OperationResult> Update(UpdateProductVariantDto dto);
        Task<OperationResult> Delete(int productVariantId, string deletedBy);

        Task<OperationResult> CreateRange(List<CreateProductVariantDto> dto);
        Task<OperationResult> UpdateRange(List<UpdateProductVariantDto> dto);
        Task<OperationResult> DeleteRange(List<int> productVariantIds, string deletedBy);
    }
}
