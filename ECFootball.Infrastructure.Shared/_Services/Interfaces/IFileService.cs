using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ECFootball.Infrastructure.Shared._Services.Interfaces
{
    public interface IFileService
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile file, string folderName);
        Task<DeletionResult> DeleteImageAsync(string publicId);
    }
}
