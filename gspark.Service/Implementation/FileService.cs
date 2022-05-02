using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using gspark.Service.Common.Behaviors;
using gspark.Service.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace gspark.Service.Implementation;

public class FileService : IFileService
{
    private readonly Cloudinary _cloudinary;
    
    public FileService(IOptions<CloudinarySettings> config)
    {
        Account account = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
        );
        
        _cloudinary = new Cloudinary(account);
    }
    
    public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();

        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.Name, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill")
            };
            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }

        return uploadResult;
    }

    public async Task<VideoUploadResult> AddFileAsync(IFormFile file)
    {
        var uploadResult = new VideoUploadResult();

        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription(file.Name, stream)
            };
            uploadResult = await _cloudinary.UploadLargeAsync(uploadParams);
        }

        return uploadResult;
    }

    public async Task<string> DownloadFile(VideoUploadResult uploadResult)
    {
        var deliveryUrl = _cloudinary.Api.UrlVideoUp.Transform(new Transformation()
                .Flags($"attachment:{uploadResult.PublicId}")
                .FetchFormat(uploadResult.Format))
            .BuildUrl(uploadResult.PublicId);
        return deliveryUrl;
    }

    public async Task<DeletionResult> DeleteFileAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);

        var result = await _cloudinary.DestroyAsync(deleteParams);
        
        return result;
    }
}