using ECFootBall.Dtos.ColorDto;
using ECFootBall.Models;

namespace ECFootBall.Helpers.Mapper
{
    public static class ColorMappingExtensions
    {
        public static Color MapToEntity(this CreateColorDto dto)
        {
            return new Color
            {
                Name = dto.Name,
                DisplayOrder = dto.DisplayOrder,
                
                CreateBy = dto.CreateBy,
                CreateDate = DateTime.UtcNow,
                IsActive = false,
                IsDelete = false,
            };
        }

        public static void MapToEntity(this UpdateColorDto dto, Color entity)
        {
            entity.Name = dto.Name;
            entity.DisplayOrder = dto.DisplayOrder;
            entity.IsActive = dto.IsActive;

            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdateBy = dto.UpdateBy;
        }

        public static ColorDto MapToDto(this Color entity)
        {
            return new ColorDto
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

        public static void MapDelete(this Color entity, string deletedBy)
        {
            entity.IsDelete = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = deletedBy;
        }
    }
}
