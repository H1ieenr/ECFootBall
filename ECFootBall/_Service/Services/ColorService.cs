using ECFootBall._Service.Interfaces;
using ECFootBall.Data;
using ECFootBall.Dtos.ColorDto;
using ECFootBall.Helpers.Mapper;
using ECFootBall.Helpers.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ECFootBall._Service.Services
{
    public class ColorService : IColorService
    {
        private ECFootBallDBContext _context;
        public ColorService(ECFootBallDBContext context) 
        {
            _context = context;
        }

        public async Task<OperationResult> Create(CreateColorDto dto)
        {
            try
            {
                var color = dto.MapToEntity();

                await _context.Colors.AddAsync(color);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> Delete(int colorId, string deletedBy)
        {
            try
            {
                var color = await _context.Colors.FindAsync(colorId);
                if (color == null) return new OperationResult() { Success = false, Message = "No data" };

                color.MapDelete(deletedBy);

                _context.Colors.Update(color);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<ColorDto> GetColorByIdAsync(int colorId)
        {
            var query = await _context.Colors.AsNoTracking().FirstOrDefaultAsync(c => c.Id == colorId);
            return query?.MapToDto();
        }

        public async Task<PaginationUtility<ColorDto>> GetPagedColorsAsync(PaginationParam pagination, SearchColorDto searchDto, bool isPaging = true)
        {
            var query = _context.Colors.AsNoTracking();

            if (searchDto.ColorId.HasValue)
                query = query.Where(c => c.Id == searchDto.ColorId);
            if (searchDto.IsDelete.HasValue)
                query = query.Where(c => c.IsDelete == searchDto.IsDelete);
            if (searchDto.IsActive.HasValue)
                query = query.Where(c => c.IsActive == searchDto.IsActive);
            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.Name.Contains(searchDto.FullTextSearch));

            var queryDto = query.Select(c => c.MapToDto());
            return await PaginationUtility<ColorDto>.CreateAsync(queryDto, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<OperationResult> Update(UpdateColorDto dto)
        {

            try
            {
                var color = await _context.Colors.FindAsync(dto.Id);
                if (color == null) return new OperationResult() { Success = false, Message = "No data" };

                dto.MapToEntity(color);
                _context.Colors.Update(color);
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
