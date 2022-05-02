using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace gspark.Service.Contract;

public interface IFileService
{
    Task<ImageUploadResult> AddImageAsync(IFormFile file);
    Task<VideoUploadResult> AddFileAsync(IFormFile file);
    Task<string> DownloadFile(VideoUploadResult uploadResult);
    Task<DeletionResult> DeleteFileAsync(string publicId);
}