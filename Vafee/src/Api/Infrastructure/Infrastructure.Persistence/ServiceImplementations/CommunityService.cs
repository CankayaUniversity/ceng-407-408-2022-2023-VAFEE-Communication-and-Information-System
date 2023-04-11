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
    public class CommunityService : BaseService<Community>,ICommunityService
    {
        public CommunityService(VafeeContext context) : base(context)
        {
            
        }
    }
}