using ECFootBall.Dtos.ProductDto;
using ECFootBall.Models;

namespace ECFootBall.Helpers.Mapper
{
    public static class ProductMappingExtensions
    {
        public static Product MapToEntity(this CreateProductDto dto)
        {
            return new Product
            {
                Id = Guid.NewGuid().ToString(), 
                Name = dto.Name,
                Price = dto.Price,
                PricePromotion = dto.PricePromotion,
                Description = dto.Description,
                CreateDate = DateTime.Now,
                IsActive = true,
                CreateBy = dto.CreateBy,
                Images = dto.Images?.Select(img => new Image
                {
                    UrlImage = img.UrlImage
                }).ToList() ?? new()
            };
        }

        public static ProductDto MapToDto(this Product entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                PricePromotion = entity.PricePromotion,
                Description = entity.Description,
                BrandId = entity.BrandId,
                
                BrandName = entity.Brand?.Name,
                ImageUrls = entity.Images?.Select(i => i.UrlImage).ToList() ?? new()
            };
        }
    }
}
