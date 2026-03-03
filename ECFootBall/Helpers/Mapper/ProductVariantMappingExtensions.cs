using ECFootball.Product.API.Dtos.ProductVariantDto;
using ECFootBall.Dtos.ProductVariantDto;
using ECFootBall.Models;

namespace ECFootball.Product.API.Helpers.Mapper
{
    public static class ProductVariantMappingExtensions
    {
        public static ProductVariant MapToEntity(this CreateProductVariantDto dto)
        {
            return new ProductVariant
            {
                StockQuantity = dto.StockQuantity,
                SizeId = dto.SizeId,
                ColorId = dto.ColorId,
                ProductId = dto.ProductId,
                
                CreateBy = dto.CreateBy,
                CreateDate = DateTime.UtcNow,
                IsDelete = false,
            };
        }

        public static void MapToEntity(this UpdateProductVariantDto dto, ProductVariant entity)
        {
            entity.StockQuantity = dto.StockQuantity;
            entity.SizeId = dto.SizeId;
            entity.ColorId = dto.ColorId;
            entity.ProductId = dto.ProductId;
            

            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdateBy = dto.UpdateBy;
        }

        public static ProductVariantDto MapToDto(this ProductVariant entity)
        {
            return new ProductVariantDto
            {
                Id = entity.Id,
                SizeId= entity.SizeId,
                StockQuantity   = entity.StockQuantity,
                ColorId= entity.ColorId,
                ProductId= entity.ProductId,

                CreateBy = entity.CreateBy,
                CreateDate = entity.CreateDate,
                IsDelete = entity.IsDelete,
                UpdateBy = entity.UpdateBy,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static void MapDelete(this ProductVariant entity, string deletedBy)
        {
            entity.IsDelete = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = deletedBy;
        }
    }
}
