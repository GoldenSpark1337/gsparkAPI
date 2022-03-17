using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace gspark.Service.Contract;

public interface IFileService
{
    Task<ImageUploadResult> AddFileAsync(IFormFile file);
    Task<DeletionResult> DeleteFileAsync(string publicId);
}