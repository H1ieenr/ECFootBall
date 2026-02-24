using ECFootBall.Dtos.SizeDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootBall._Service.Interfaces
{
    public interface ISizeService
    {
        Task<PaginationUtility<SizeDto>> GetPagedSizesAsync(PaginationParam pagination, SearchSizeDto dto, bool isPaging = true);
        Task<SizeDto> GetSizeByIdAsync(int sizeId);
        Task<OperationResult> Create(CreateSizeDto dto);
        Task<OperationResult> Update(UpdateSizeDto dto);
        Task<OperationResult> Delete(int sizeId, string deletedBy);
    }
}
