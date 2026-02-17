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
                CategoryId = dto.CategoryId,
                CreateDate = DateTime.Now,
                IsActive = true,
                CreateBy = dto.CreateBy,
                Images = dto.Images?.Select(img => new Image
                {
                    UrlImage = img.UrlImage
                }).ToList() ?? new()
            };
        }
    }
}
