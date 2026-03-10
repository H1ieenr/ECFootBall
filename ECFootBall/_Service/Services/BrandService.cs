using ECFootball.Product.API._Service.Interfaces;
using ECFootBall._Service.Interfaces;
using ECFootBall.Data;
using ECFootBall.Dtos.BrandDto;
using ECFootBall.Dtos.ImageDto;
using ECFootBall.Helpers.Mapper;
using ECFootBall.Helpers.Utilities;
using ECFootBall.Models;
using Microsoft.EntityFrameworkCore;

namespace ECFootBall._Service.Services
{
    public class BrandService : IBrandService
    {
        private ECFootBallDBContext _context;
        private IImageService _imageService;
        public BrandService(ECFootBallDBContext context, IImageService imageService) 
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<OperationResult> Create(CreateBrandDto dto)
        {
            try
            {
                Brand brand = dto.MapToEntity();
                
                if (dto.FileAvatar != null)
                {
                    CreateImageObjectDto imageDto = new CreateImageObjectDto { ObjectId = $"{brand.Name}", ObjectName = "Brand" };
                    OperationResult resutlImage = await _imageService.AddImageToObjectAsync(imageDto, dto.FileAvatar);
                    if (resutlImage.Success) { brand.Avatar = ((Image)resutlImage.Data).UrlImage; }
                }
                await _context.Brands.AddAsync(brand);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> Delete(int brandId, string deletedBy)
        {
            try
            {
                Brand brand = await _context.Brands.FindAsync(brandId);
                if (brand == null) return new OperationResult() { Success = false, Message = "No data" };

                brand.MapDelete(deletedBy);

                _context.Brands.Update(brand);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<BrandDto> GetBrandByIdAsync(int brandId)
        {
            Brand query = await _context.Brands.AsNoTracking().FirstOrDefaultAsync(c => c.Id == brandId);
            return query?.MapToDto();
        }

        public async Task<PaginationUtility<BrandDto>> GetPagedBrandsAsync(PaginationParam pagination, SearchBrandDto searchDto, bool isPaging = true)
        {
            var query = _context.Brands.AsNoTracking();

            if (searchDto.BrandId.HasValue)
                query = query.Where(c => c.Id == searchDto.BrandId);
            if (searchDto.IsDelete.HasValue)
                query = query.Where(c => c.IsDelete == searchDto.IsDelete);
            if (searchDto.IsActive.HasValue)
                query = query.Where(c => c.IsActive == searchDto.IsActive);
            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.Name.Contains(searchDto.FullTextSearch));

            var queryDto = query.Select(c => c.MapToDto());
            return await PaginationUtility<BrandDto>.CreateAsync(queryDto, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<OperationResult> Update(UpdateBrandDto dto)
        {
            try
            {
                Brand brand = await _context.Brands.FindAsync(dto.Id);
                if (brand == null) return new OperationResult() { Success = false, Message = "No data" };

                dto.MapToEntity(brand);

                if (dto.FileAvatar != null)
                {
                    CreateImageObjectDto imageDto = new CreateImageObjectDto { ObjectId = $"{brand.Name}", ObjectName = "Brand" };

                    var resultImage = await _imageService.AddImageToObjectAsync(imageDto, dto.FileAvatar);
                    if (resultImage.Success)
                    {
                        await _imageService.DeleteImageAsync(brand.Avatar);
                        brand.Avatar = ((Image)resultImage.Data).UrlImage;
                    }
                }
                _context.Brands.Update(brand);
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
