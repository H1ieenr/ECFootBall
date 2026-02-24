using ECFootBall._Service.Interfaces;
using ECFootBall.Data;
using ECFootBall.Dtos.SizeDto;
using ECFootBall.Helpers.Mapper;
using ECFootBall.Helpers.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ECFootBall._Service.Services
{
    public class SizeService : ISizeService
    {
        private ECFootBallDBContext _context;
        public SizeService(ECFootBallDBContext context) 
        {
            _context = context;
        }

        public async Task<OperationResult> Create(CreateSizeDto dto)
        {
            try
            {
                var size = dto.MapToEntity();

                await _context.Sizes.AddAsync(size);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> Delete(int sizeId, string deletedBy)
        {
            try
            {
                var size = await _context.Sizes.FindAsync(sizeId);
                if (size == null) return new OperationResult() { Success = false, Message = "No data" };

                size.MapDelete(deletedBy);

                _context.Sizes.Update(size);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<PaginationUtility<SizeDto>> GetPagedSizesAsync(PaginationParam pagination, SearchSizeDto searchDto, bool isPaging = true)
        {
            var query = _context.Sizes.AsNoTracking();

            if (searchDto.SizeId.HasValue)
                query = query.Where(c => c.Id == searchDto.SizeId);
            if (searchDto.IsDelete.HasValue)
                query = query.Where(c => c.IsDelete == searchDto.IsDelete);
            if (searchDto.IsActive.HasValue)
                query = query.Where(c => c.IsActive == searchDto.IsActive);
            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.Name.Contains(searchDto.FullTextSearch));

            var queryDto = query.Select(c => c.MapToDto());
            return await PaginationUtility<SizeDto>.CreateAsync(queryDto, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<SizeDto> GetSizeByIdAsync(int sizeId)
        {
            var query = await _context.Sizes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == sizeId);
            return query?.MapToDto();
        }

        public async Task<OperationResult> Update(UpdateSizeDto dto)
        {
            try
            {
                var size = await _context.Sizes.FindAsync(dto.Id);
                if (size == null) return new OperationResult() { Success = false, Message = "No data" };

                dto.MapToEntity(size);
                _context.Sizes.Update(size);
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
