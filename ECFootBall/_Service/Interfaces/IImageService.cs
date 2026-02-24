using ECFootBall.Dtos.ImageDto;
using ECFootBall.Helpers.Utilities;

namespace ECFootball.Product.API._Service.Interfaces
{
    public interface IImageService
    {
        Task<OperationResult> AddImageToProductAsync(CreateImageDto dto, IFormFile file);
        Task<OperationResult> AddMultipleImagesToProductAsync(CreateImageDto dto, List<IFormFile> files);
        Task<OperationResult> DeleteImageAsync(Guid imageId);
    }
}
