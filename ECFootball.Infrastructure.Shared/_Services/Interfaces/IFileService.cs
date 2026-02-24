using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ECFootball.Infrastructure.Shared._Services.Interfaces
{
    public interface IFileService
    {
        Task<List<ImageUploadResult>> UploadMultipleImagesAsync(List<IFormFile> files, string folderName);
        Task<ImageUploadResult> UpdateImageAsync(string oldPublicId, IFormFile newFile, string folderName);
        Task<ImageUploadResult> UploadImageAsync(IFormFile file, string folderName);
        Task<DeletionResult> DeleteImageAsync(string publicId);
    }
}
