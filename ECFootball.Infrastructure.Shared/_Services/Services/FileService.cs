using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ECFootball.Infrastructure.Shared._Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ECFootball.Infrastructure.Shared._Services.Services
{
    public class FileService : IFileService
    {
        private readonly Cloudinary _cloudinary;
        private string folderProject = "ECFootball";
        public FileService(IConfiguration config)
        {
            var acc = new Account(
                config["CloudinarySettings:CloudName"],
                config["CloudinarySettings:ApiKey"],
                config["CloudinarySettings:ApiSecret"]
            );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile file, string folderName)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = folderProject + folderName,
                    Transformation = new Transformation().Quality("auto").FetchFormat("auto")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<List<ImageUploadResult>> UploadMultipleImagesAsync(List<IFormFile> files, string folderName)
        {
            var uploadTasks = files
                .Where(f => f.Length > 0)
                .Select(file => UploadImageAsync(file, folderName)); 

            var results = await Task.WhenAll(uploadTasks);

            return results.ToList();
        }

        public async Task<ImageUploadResult> UpdateImageAsync(string oldPublicId, IFormFile newFile, string folderName)
        {
            if (!string.IsNullOrEmpty(oldPublicId))
            {
                await DeleteImageAsync(oldPublicId);
            }

            return await UploadImageAsync(newFile, folderName);
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deleteParams);
        }
    
    }
}
