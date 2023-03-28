using Api.Application.DTO.Responses;
using Api.Application.Services;
using Api.Domain.Models.Identity;

namespace Infrastructure.Persistence.ServiceImplementations;

public class AuthManager: IAuthManager
{

    public AuthManager()
    {
        
    }
    
    public async Task<AuthResponseDto> Register(User user, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponseDto> LoginWithEmail(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponseDto> LoginWithUsername(string username, string password)
    {
        throw new NotImplementedException();
    }
}