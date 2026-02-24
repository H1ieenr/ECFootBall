using ECFootBall.Dtos.SizeDto;
using ECFootBall.Models;

namespace ECFootBall.Helpers.Mapper
{
    public static class SizeMappingExtensions
    {
        public static Size MapToEntity(this CreateSizeDto dto)
        {
            return new Size
            {
                Name = dto.Name,
                DisplayOrder = dto.DisplayOrder,
                
                CreateBy = dto.CreateBy,
                CreateDate = DateTime.UtcNow,
                IsActive = false,
                IsDelete = false,
            };
        }

        public static void MapToEntity(this UpdateSizeDto dto, Size entity)
        {
            entity.Name = dto.Name;
            entity.DisplayOrder = dto.DisplayOrder;
            entity.IsActive = dto.IsActive;
            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdateBy = dto.UpdateBy;
        }

        public static SizeDto MapToDto(this Size entity)
        {
            return new SizeDto
            {
                Id = entity.Id,
                Name = entity.Name,
                CreateBy = entity.CreateBy,
                CreateDate = entity.CreateDate,
                DisplayOrder = entity.DisplayOrder,
                IsActive = entity.IsActive,
                IsDelete = entity.IsDelete,
                UpdateBy = entity.UpdateBy,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static void MapDelete(this Size entity, string deletedBy)
        {
            entity.IsDelete = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = deletedBy;
        }
    }
}
