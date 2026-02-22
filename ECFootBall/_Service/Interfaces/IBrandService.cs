using ECFootBall.Dtos.BrandDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootBall._Service.Interfaces
{
    public interface IBrandService
    {
        Task<PaginationUtility<BrandDto>> GetPagedBrandsAsync(PaginationParam pagination, SearchBrandDto dto, bool isPaging = true);
        Task<BrandDto> GetBrandByIdAsync(int brandId);
        Task<OperationResult> Create(CreateBrandDto dto);
        Task<OperationResult> Update(UpdateBrandDto dto);
        Task<OperationResult> Delete(int brandId, string deletedBy);
    }
}
