using ECFootBall.Dtos.CategoryDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootBall._Service.Interfaces
{
    public interface ICategoryService
    {
        Task<PaginationUtility<CategoryDto>> GetPagedCategoriesAsync(PaginationParam pagination, SearchCategoryDto dto, bool isPaging = true);
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<OperationResult> Create(CreateCategoryDto dto);
        Task<OperationResult> Update(UpdateCategoryDto dto);
        Task<OperationResult> Delete(int categoryId, string deletedBy);
    }
}
