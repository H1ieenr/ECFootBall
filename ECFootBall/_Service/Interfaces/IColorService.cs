using ECFootBall.Dtos.ColorDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootBall._Service.Interfaces
{
    public interface IColorService
    {
        Task<PaginationUtility<ColorDto>> GetPagedColorsAsync(PaginationParam pagination, SearchColorDto dto, bool isPaging = true);
        Task<ColorDto> GetColorByIdAsync(int colorId);
        Task<OperationResult> Create(CreateColorDto dto);
        Task<OperationResult> Update(UpdateColorDto dto);
        Task<OperationResult> Delete(int colorId, string deletedBy);
    }
}
