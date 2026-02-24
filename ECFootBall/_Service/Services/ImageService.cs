using CloudinaryDotNet.Actions;
using ECFootball.Infrastructure.Shared._Services.Interfaces;
using ECFootball.Product.API._Service.Interfaces;
using ECFootball.Product.API.Helpers.Mapper;
using ECFootBall.Data;
using ECFootBall.Dtos.ImageDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootball.Product.API._Service.Services
{
    public class ImageService : IImageService
    {
        private readonly IFileService _fileService;
        private readonly ECFootBallDBContext _context;
        public ImageService(IFileService fileService, ECFootBallDBContext context)
        {
            _fileService = fileService;
            _context = context;
        }

        public async Task<OperationResult> AddImageToProductAsync(CreateImageDto dto, IFormFile file)
        {
            try
            {
                var uploadResult = await _fileService.UploadImageAsync(file, "Product");
                if (uploadResult.Error != null) return new OperationResult() { Success = false, Message = "Upload Image error" };

                var image = dto.MapToEntity();
                image.PublicId = uploadResult.PublicId;
                image.UrlImage = uploadResult.SecureUrl.AbsoluteUri;

                _context.Images.Add(image);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Data = image, Message = "Create Success" };
            }
            catch (Exception ex) 
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> AddMultipleImagesToProductAsync(CreateImageDto dto, List<IFormFile> files)
        {
            try
            {
                var uploadResults = await _fileService.UploadMultipleImagesAsync(files, "Product");
                foreach (var result in uploadResults) 
                { if (result.Error != null) return new OperationResult() { Success = false, Message = "Upload Image error" }; }

                var images = uploadResults.Select(res =>
                {
                    var img = dto.MapToEntity();
                    img.PublicId = res.PublicId;
                    img.UrlImage = res.SecureUrl.AbsoluteUri;
                    return img;
                }).ToList();

                _context.Images.AddRange(images);
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Data = images, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> DeleteImageAsync(Guid imageId)
        {
            var image = await _context.Images.FindAsync(imageId);
            if (image == null) return new OperationResult { Success = false, Message = "Image not found" };

            if (!string.IsNullOrEmpty(image.PublicId))
            {
                var deleteResult = await _fileService.DeleteImageAsync(image.PublicId);
                if (deleteResult.Error != null)
                {
                    return new OperationResult() { Success = false, Message = "Delete Image error" };
                }
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Delete Success" };
        }
    }
}
