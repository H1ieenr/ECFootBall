using ECFootBall._Service.Interfaces;
using ECFootBall.Data;
using ECFootBall.Dtos.BrandDto;
using ECFootBall.Helpers.Mapper;
using ECFootBall.Helpers.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ECFootBall._Service.Services
{
    public class BrandService : IBrandService
    {
        private ECFootBallDBContext _context;
        public BrandService(ECFootBallDBContext context) 
        {
            _context = context;
        }

        public async Task<OperationResult> Create(CreateBrandDto dto)
        {
            try
            {
                var brand = dto.MapToEntity();

                await _context.Brands.AddAsync(brand);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> Delete(int brandId, string deletedBy)
        {
            try
            {
                var brand = await _context.Brands.FindAsync(brandId);
                if (brand == null) return new OperationResult() { Success = false, Message = "No data" };

                brand.MapDelete(deletedBy);

                _context.Brands.Update(brand);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<BrandDto> GetBrandByIdAsync(int brandId)
        {
            var query = await _context.Brands.AsNoTracking().FirstOrDefaultAsync(c => c.Id == brandId);
            return query?.MapToDto();
        }

        public async Task<PaginationUtility<BrandDto>> GetPagedBrandsAsync(PaginationParam pagination, SearchBrandDto searchDto, bool isPaging = true)
        {
            var query = _context.Brands.AsNoTracking();

            if (searchDto.BrandId.HasValue)
                query = query.Where(c => c.Id == searchDto.BrandId);
            if (searchDto.IsDelete.HasValue)
                query = query.Where(c => c.IsDelete == searchDto.IsDelete);
            if (searchDto.IsActive.HasValue)
                query = query.Where(c => c.IsActive == searchDto.IsActive);
            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.Name.Contains(searchDto.FullTextSearch));

            var queryDto = query.Select(c => c.MapToDto());
            return await PaginationUtility<BrandDto>.CreateAsync(queryDto, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<OperationResult> Update(UpdateBrandDto dto)
        {
            try
            {
                var brand = await _context.Brands.FindAsync(dto.Id);
                if (brand == null) return new OperationResult() { Success = false, Message = "No data" };

                dto.MapToEntity(brand);
                _context.Brands.Update(brand);
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
