using Api.Application.DTO.Responses;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Services;

public interface IBaseService<TEntity> where TEntity : class
{
    public DbSet<TEntity> Table { get; }

    Task<ServiceResponse<TEntity>> GetByIdAsync(string id);
    Task<ServiceResponse<IEnumerable<TEntity>>> GetAllAsync();
    Task<ServiceResponse<TEntity>> AddAsync(TEntity entity);
    Task<ServiceResponse<TEntity>> UpdateAsync(TEntity entity);
    Task<ServiceResponse<TEntity>> DeleteAsync(string id);
}