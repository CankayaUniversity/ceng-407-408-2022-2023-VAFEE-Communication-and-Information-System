using System.Linq.Expressions;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Domain.Models;

namespace Api.Application.Services;

public interface ICommunityService
{
    IQueryable<GetCommunityDto> GetAllCommunities();
    Task<IQueryable<GetCommunityDto>> GetAllCommunitiesWhereAsync(Expression<Func<Community, bool>> expression);
    Task<GetCommunityDto> GetCommunityByIdAsync(string communityId);

    Task<bool> RemoveCommunityAsync(string communityId);
    Task<bool> RemoveCommunityAsync(Community community);
    Task<bool> RemoveAllCommunitiesWhereAsync(Expression<Func<Community, bool>> expression);

    Task<bool> AddCommunityAsync(CreateCommunityDto community);
    Task<bool> AddCommunitiesAsync(IEnumerable<CreateCommunityDto> communities);
}