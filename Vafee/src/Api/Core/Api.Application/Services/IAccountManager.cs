namespace Api.Application.Services;

public interface IAccountManager
{
    Task<bool> ChangePasswordAsync(string userId, string newPassword);
    Task<bool> ChangeUsernameAsync(string userId, string newUsername);
    Task<bool> ChangeProfilePictureAsync(string userId, string newProfilePicture);
    Task<bool> ChangeFullNameAsync(string userId, string newFullName);
}