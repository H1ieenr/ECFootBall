using ECFootball.Product.API.Dtos.ProductDto;
namespace ECFootball.Product.API.Helpers.Mapper
{
    public static class ProductMappingExtensions
    {
        public static ECFootBall.Models.Product MapToEntity(this CreateProductDto dto)
        {
            return new ECFootBall.Models.Product
            {
                Id = ECFootBall.Helpers.Utilities.Utilities.GenerateProductId(dto.BrandName ,dto.Name),
                Price = dto.Price,
                PricePromotion = dto.PricePromotion,
                Name = dto.Name,
                Description = dto.Description,
                BrandId = dto.BrandId,
                Avatar = dto.Avatar,
                IsPromotion = dto.IsPromotion,
                CreateBy = dto.CreateBy,
                CreateDate = DateTime.UtcNow,
                IsActive = false,
                IsDelete = false,
            };
        }

        public static void MapToEntity(this UpdateProductDto dto, ECFootBall.Models.Product entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.IsActive = dto.IsActive;
            entity.Price = dto.Price;
            entity.PricePromotion = dto.PricePromotion;
            entity.BrandId = dto.BrandId;
            entity.Avatar = dto.Avatar;
            entity.IsPromotion = dto.IsPromotion;

            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdateBy = dto.UpdateBy;
        }

        public static ProductDto MapToDto(this ECFootBall.Models.Product entity)
        {
            if (entity == null) return null;

            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreateBy = entity.CreateBy,
                CreateDate = entity.CreateDate,
                IsActive = entity.IsActive,
                IsDelete = entity.IsDelete,
                UpdateBy = entity.UpdateBy,
                UpdateDate = entity.UpdateDate,
                AmountReview = entity.AmountReview,
                Avatar = entity.Avatar,
                Price = entity.Price,
                PricePromotion = entity.PricePromotion,
                BrandId = entity.BrandId,
                BrandName = entity.Brand?.Name,
                IsPromotion = entity.IsPromotion,
                Images = string.Join("|", entity.Images?.Select(i => i.UrlImage) ?? new List<string>()),
                Variants = entity.Variants?.Select(v => v.MapToDto()).ToList()
            };
        }

        public static void MapDelete(this ECFootBall.Models.Product entity, string deletedBy)
        {
            entity.IsDelete = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = deletedBy;
        }
    }
}
