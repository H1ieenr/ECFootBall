using ECFootBall._Service.Interfaces;
using ECFootBall.Data;
using ECFootBall.Dtos.CategoryDto;
using ECFootBall.Helpers.Mapper;
using ECFootBall.Helpers.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ECFootBall._Service.Services
{
    public class CategoryService : ICategoryService
    {
        private ECFootBallDBContext _context;
        public CategoryService(ECFootBallDBContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var query = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == categoryId);
            return query?.MapToDto();
        }

        public async Task<PaginationUtility<CategoryDto>> GetPagedCategoriesAsync(PaginationParam pagination, SearchCategoryDto searchDto, bool isPaging = true)
        {
            var query = _context.Categories.AsNoTracking();

            if (searchDto.BrandId.HasValue)
                query = query.Where(c => c.BrandId == searchDto.BrandId);
            if (searchDto.IsDelete.HasValue)
                query = query.Where(c => c.IsDelete == searchDto.IsDelete);
            if (searchDto.ParentId.HasValue)
                query = query.Where(c => c.ParentId == searchDto.ParentId);
            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.Name.Contains(searchDto.FullTextSearch));

            var queryDto = query.Select(c => c.MapToDto());
            return await PaginationUtility<CategoryDto>.CreateAsync(queryDto, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<OperationResult> Create(CreateCategoryDto dto)
        {
            try
            {
                var category = dto.MapToEntity();

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> Delete(int CategoryId, string deletedBy)
        {
            try
            {
                var category = await _context.Categories.FindAsync(CategoryId);
                if (category == null) return new OperationResult() { Success = false, Message = "No data" };

                category.MapDelete(deletedBy);

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> Update(UpdateCategoryDto dto)
        {
            try
            {
                var category = await _context.Categories.FindAsync(dto.Id);
                if (category == null) return new OperationResult() { Success = false, Message = "No data" };
                
                dto.MapToEntity(category);
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Update Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }
    }
}
