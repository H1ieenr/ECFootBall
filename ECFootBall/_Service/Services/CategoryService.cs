using ECFootBall._Service.Interfaces;
using ECFootBall.Data;
using ECFootBall.Dtos.CategoryDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootBall._Service.Services
{
    public class CategoryService : ICategory
    {
        private ECFootBallDBContext _context;
        public CategoryService(ECFootBallDBContext context)
        {
            _context = context;
        }

        public Task<OperationResult> Create(CreateCategoryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Delete(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationUtility<CategoryDto>> GetListCategory(PaginationParam pagination, SearchCategoryDto dto, bool isPaging = true)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(UpdateCategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
