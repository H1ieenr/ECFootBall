using ECFootBall.Dtos.CategoryDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootBall._Service.Interfaces
{
    public interface ICategory
    {
        Task<PaginationUtility<CategoryDto>> GetListCategory(PaginationParam pagination, SearchCategoryDto dto, bool isPaging = true);
        Task<CategoryDto> GetCategory(int CategoryId);
        Task<OperationResult> Create(CreateCategoryDto dto);
        Task<OperationResult> Update(UpdateCategoryDto dto);
        Task<OperationResult> Delete(int CategoryId);
    }
}
