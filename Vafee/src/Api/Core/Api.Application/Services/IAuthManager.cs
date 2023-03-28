using Api.Application.DTO.Responses;
using Api.Domain.Models.Identity;

namespace Api.Application.Services;

public interface IAuthManager
{
    Task<AuthResponseDto> Register(User user, string password);
    Task<AuthResponseDto> LoginWithEmail(string email, string password);
    Task<AuthResponseDto> LoginWithUsername(string username, string password);
}