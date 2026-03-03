using ECFootball.Product.API._Service.Interfaces;
using ECFootball.Product.API.Dtos.ProductVariantDto;
using ECFootball.Product.API.Helpers.Mapper;
using ECFootBall.Data;
using ECFootBall.Dtos.ProductVariantDto;
using ECFootBall.Helpers.Mapper;
using ECFootBall.Helpers.Utilities;
using ECFootBall.Models;
using Microsoft.EntityFrameworkCore;

namespace ECFootball.Product.API._Service.Services
{
    public class ProductVariantService : IProductVariantService
    {
        private ECFootBallDBContext _context;
        public ProductVariantService(ECFootBallDBContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> Create(CreateProductVariantDto dto)
        {
            try
            {
                bool isDuplicate = await _context.ProductVariants.AnyAsync(c => c.ProductId == dto.ProductId && c.ColorId == dto.ColorId 
                                                                                                && c.SizeId == dto.SizeId && c.IsDelete == false);
                if (isDuplicate) { return new OperationResult() { Success = false, Message = "Product Exist" }; }
                ProductVariant productVariant = dto.MapToEntity();

                await _context.ProductVariants.AddAsync(productVariant);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> CreateRange(List<CreateProductVariantDto> dtos)
        {
            try
            {
                var entities = new List<ProductVariant>();

                foreach (var item in dtos) 
                {
                    bool isDuplicate = await _context.ProductVariants.AnyAsync(c => c.ProductId == item.ProductId && c.ColorId == item.ColorId
                                                                                                && c.SizeId == item.SizeId && c.IsDelete == false);

                    if (!isDuplicate)
                    {
                        entities.Add(item.MapToEntity());
                    }
                }

                if (entities.Count > 0)
                {
                    await _context.ProductVariants.AddRangeAsync(entities);
                    await _context.SaveChangesAsync();
                    return new OperationResult { Success = true, Message = $"Đã thêm thành công {entities.Count} biến thể." };
                }
                return new OperationResult() { Success = false, Message = "All Product Exist" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> Delete(int productVariantId, string deletedBy)
        {
            try
            {
                ProductVariant productVariant = await _context.ProductVariants.FindAsync(productVariantId);
                if (productVariant == null) return new OperationResult() { Success = false, Message = "No data" };

                productVariant.MapDelete(deletedBy);

                _context.ProductVariants.Update(productVariant);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> DeleteRange(List<int> productVariantIds, string deletedBy)
        {
            try
            {
                var existingVariants = await _context.ProductVariants.Where(v => productVariantIds.Contains(v.Id) && v.IsDelete == false).ToListAsync();
                if (existingVariants.Count == 0)
                    return new OperationResult { Success = false, Message = "No Data" };

                foreach (var variant in existingVariants)
                {
                    variant.MapDelete(deletedBy);
                }

                _context.ProductVariants.UpdateRange(existingVariants);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<PaginationUtility<ProductVariantDto>> GetPagedProductVariantsAsync(PaginationParam pagination, SearchProductVariantDto searchDto, bool isPaging = true)
        {
            var query = _context.ProductVariants.AsNoTracking();

            if (searchDto.IsDelete.HasValue)
                query = query.Where(c => c.IsDelete == searchDto.IsDelete);
            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.ProductId.Contains(searchDto.FullTextSearch));

            var queryDto = query.Select(c => c.MapToDto());
            return await PaginationUtility<ProductVariantDto>.CreateAsync(queryDto, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<ProductVariantDto> GetProductVariantByIdAsync(int productVariantId)
        {
            ProductVariant query = await _context.ProductVariants.AsNoTracking().FirstOrDefaultAsync(c => c.Id == productVariantId);
            return query?.MapToDto();
        }

        public async Task<OperationResult> Update(UpdateProductVariantDto dto)
        {
            try
            {
                ProductVariant productVariant = await _context.ProductVariants.FindAsync(dto.Id);
                if (productVariant == null) return new OperationResult() { Success = false, Message = "No data" };

                var isDuplicate = await _context.ProductVariants.AnyAsync(c => c.ProductId == productVariant.ProductId && c.ColorId == dto.ColorId 
                                                                                             && c.SizeId == dto.SizeId && c.Id != dto.Id && c.IsDelete == false);

                if (isDuplicate){return new OperationResult { Success = false, Message = "Product Exist" };}

                dto.MapToEntity(productVariant);
                _context.ProductVariants.Update(productVariant);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Update Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> UpdateRange(List<UpdateProductVariantDto> dtos)
        {
            try
            {
                var ids = dtos.Select(x => x.Id).ToList();
                var existingVariants = await _context.ProductVariants.Where(v => ids.Contains(v.Id)).ToListAsync();

                foreach (var dto in dtos)
                {
                    var variant = existingVariants.FirstOrDefault(v => v.Id == dto.Id);
                    if (variant != null)
                    {
                        bool isDuplicate = await _context.ProductVariants.AnyAsync(c =>
                            c.ProductId == variant.ProductId &&
                            c.ColorId == dto.ColorId &&
                            c.SizeId == dto.SizeId &&
                            c.Id != dto.Id &&
                            c.IsDelete == false);

                        if (!isDuplicate)
                        {
                            dto.MapToEntity(variant); 
                        }
                    }
                }

                _context.ProductVariants.UpdateRange(existingVariants);
                await _context.SaveChangesAsync();

                return new OperationResult { Success = true, Message = "Update Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }
    }
}
