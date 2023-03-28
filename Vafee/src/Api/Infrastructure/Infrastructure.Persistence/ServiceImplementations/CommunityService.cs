using System.Linq.Expressions;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Application.Services;
using Api.Domain.Models;
using Infrastructure.Persistence.Context;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.ServiceImplementations
{
    public class CommunityService : ICommunityService
    {
        private readonly VafeeContext _context;
        private readonly IMapper _mapper;

        public CommunityService(VafeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<GetCommunityDto> GetAllCommunities()
        {
            return _context.Communities.AsNoTrackingWithIdentityResolution().Adapt<IQueryable<GetCommunityDto>>();
        }

        public Task<IQueryable<GetCommunityDto>> GetAllCommunitiesWhereAsync(
            Expression<Func<Community, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<GetCommunityDto> GetCommunityByIdAsync(string communityId)
        {
            var record = await _context.Communities.FindAsync(communityId);
            return record?.Adapt<GetCommunityDto>();
        }

        public Task<bool> RemoveAllCommunitiesWhereAsync(Expression<Func<Community, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddCommunityAsync(CreateCommunityDto community)
        {
            var record = community.Adapt<Community>();
            await _context.Communities.AddAsync(record);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddCommunitiesAsync(IEnumerable<CreateCommunityDto> communities)
        {
            var records = communities.Adapt<IEnumerable<Community>>();
            await _context.Communities.AddRangeAsync(records);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveCommunityAsync(string communityId)
        {
            var communityToDelete = await _context.Communities.FindAsync(communityId);
            if (communityToDelete == null)
            {
                return false;
            }

            _context.Communities.Remove(communityToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveCommunityAsync(Community community)
        {
            _context.Communities.Remove(community);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}