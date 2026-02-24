using ECFootball.Product.API.Dtos.ImageDto;
using ECFootBall.Dtos.ImageDto;
using ECFootBall.Models;

namespace ECFootball.Product.API.Helpers.Mapper
{
    public static class ImageMappingExtensions
    {
        public static Image MapToEntity(this CreateImageDto dto)
        {
            return new Image
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                CreateBy = dto.CreateBy,
                CreateDate = DateTime.UtcNow,
            };
        }

        public static ImageDto MapToDto(this Image entity)
        {
            return new ImageDto
            {
                Id = entity.Id,
                Position = entity.Position,
                ProductId = entity.ProductId,
                PublicId  = entity.PublicId,
                UrlImage = entity.UrlImage,
                CreateBy = entity.CreateBy,
                CreateDate = entity.CreateDate,
                UpdateBy = entity.UpdateBy,
                UpdateDate = entity.UpdateDate,
            };
        }
    }
}
