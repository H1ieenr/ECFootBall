using ECFootball.Product.API._Service.Interfaces;
using ECFootball.Product.API.Dtos.ProductDto;
using ECFootball.Product.API.Dtos.ProductVariantDto;
using ECFootball.Product.API.Helpers.Mapper;
using ECFootBall._Service.Interfaces;
using ECFootBall.Data;
using ECFootBall.Dtos.ImageDto;
using ECFootBall.Helpers.Mapper;
using ECFootBall.Helpers.Utilities;
using ECFootBall.Models;
using Microsoft.EntityFrameworkCore;

namespace ECFootball.Product.API._Service.Services
{
    public class ProductService : IProductService
    {
        private ECFootBallDBContext _context;
        private IBrandService _brandService;
        private IImageService _imageService;
        public ProductService(ECFootBallDBContext context, IBrandService brandService, IImageService imageService)
        {
            _context = context;
            _brandService = brandService;
            _imageService = imageService;
        }

        public async Task<OperationResult> Create(CreateProductDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var brand = await _brandService.GetBrandByIdAsync(dto.BrandId);
                if (brand == null) return new OperationResult() { Success = false, Message = "No data Brand" };
                else dto.BrandName = brand.Name;

                var product = dto.MapToEntity();
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                CreateImageDto imageDto = new CreateImageDto { ProductId = product.Id };
                if (dto.FileAvatar != null)
                {
                    OperationResult resutlImage = await _imageService.AddImageToProductAsync(imageDto, dto.FileAvatar);
                    if (resutlImage.Success) { product.Avatar = ((Image)resutlImage.Data).UrlImage; }
                }
                if (dto.FileImage.Count > 0) { await _imageService.AddMultipleImagesToProductAsync(imageDto, dto.FileImage); }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return new OperationResult() { Success = true, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> Delete(string productId, string deletedBy)
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null) return new OperationResult() { Success = false, Message = "No data" };

                product.MapDelete(deletedBy);

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<PaginationUtility<ProductDto>> GetPagedProductsAsync(PaginationParam pagination, SearchProductDto searchDto, bool isPaging = true)
        {
            var query = _context.Products.AsNoTracking();

            if (!string.IsNullOrEmpty(searchDto.ProductId))
                query = query.Where(c => c.Id == searchDto.ProductId);
            if (searchDto.BrandId.HasValue)
                query = query.Where(c => c.BrandId == searchDto.BrandId);
            if (searchDto.IsDelete.HasValue)
                query = query.Where(c => c.IsDelete == searchDto.IsDelete);
            if (searchDto.IsActive.HasValue)
                query = query.Where(c => c.IsActive == searchDto.IsActive);
            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.Name.Contains(searchDto.FullTextSearch));

            var queryDto = query.Select(c => c.MapToDto());
            return await PaginationUtility<ProductDto>.CreateAsync(queryDto, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<ProductDto> GetProductByIdAsync(string ProductId)
        {
            var product = await _context.Products.AsNoTracking()
                       .Where(p => p.Id == ProductId)
                       .Select(p => new ProductDto
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Description = p.Description,
                           CreateBy = p.CreateBy,
                           CreateDate = p.CreateDate,
                           IsActive = p.IsActive,
                           IsDelete = p.IsDelete,
                           UpdateBy = p.UpdateBy,
                           UpdateDate = p.UpdateDate,
                           AmountReview = p.AmountReview,
                           Avatar = p.Avatar,
                           Price = p.Price,
                           PricePromotion = p.PricePromotion,
                           BrandId = p.BrandId,
                           BrandName = p.Brand.Name,
                           IsPromotion = p.IsPromotion,
                           Variants = p.Variants.Select(v => new ProductVariantDto
                           {
                               Id = v.Id,
                               SizeId = v.SizeId,
                               SizeName = _context.Sizes.FirstOrDefault(s => s.Id.ToString() == v.SizeId).Name,
                               ColorId = v.ColorId,
                               ColorName = _context.Colors.FirstOrDefault(c => c.Id.ToString() == v.ColorId).Name,
                               StockQuantity = v.StockQuantity
                           }).ToList(),
                           Images = string.Join("|", p.Images.Select(i => i.UrlImage))
                       })
                     .FirstOrDefaultAsync();
            return product;
        }

        public async Task<OperationResult> Update(UpdateProductDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var product = await _context.Products.FindAsync(dto.Id);
                if (product == null) return new OperationResult() { Success = false, Message = "No data Product" };

                var brand = await _brandService.GetBrandByIdAsync(dto.BrandId);
                if (brand == null) return new OperationResult() { Success = false, Message = "No data Brand" };
                else dto.BrandName = brand.Name;

                dto.MapToEntity(product);

                var imageDto = new CreateImageDto { ProductId = product.Id };
                if (dto.FileAvatar != null)
                {
                    var resultImage = await _imageService.AddImageToProductAsync(imageDto, dto.FileAvatar);
                    if (resultImage.Success)
                    {
                        await _imageService.DeleteImageAsync(product.Avatar);
                        product.Avatar = ((Image)resultImage.Data).UrlImage;
                    }
                }

                if (dto.UrlImagesToDelete?.Count > 0) { foreach (var urlImage in dto.UrlImagesToDelete) { await _imageService.DeleteImageAsync(urlImage); } }
                if (dto.FileImage?.Count > 0) { await _imageService.AddMultipleImagesToProductAsync(imageDto, dto.FileImage); }

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return new OperationResult() { Success = true, Message = "Update Success" };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }
    }
}
