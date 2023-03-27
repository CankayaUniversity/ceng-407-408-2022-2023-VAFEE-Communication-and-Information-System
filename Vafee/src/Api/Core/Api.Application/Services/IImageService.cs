using Microsoft.AspNetCore.Http;

namespace Api.Application.Services;

public interface IImageService
{
    Task<bool> AddUserImageFromFormAsync(string userId, IFormFile image);
    Task<bool> AddUserImageFromBase64Async(string userId, string base64Image);
    
}