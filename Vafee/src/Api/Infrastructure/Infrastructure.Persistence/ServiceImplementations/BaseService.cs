using Api.Application.DTO.Responses;
using Api.Application.Services;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.ServiceImplementations;

public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
{
    private readonly VafeeContext _context;

    public BaseService(VafeeContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();

    public async Task<ServiceResponse<TEntity>> GetByIdAsync(string id)
    {
        var response = new ServiceResponse<TEntity>();
        var record = await Table.FindAsync(id);

        if (record != null)
        {
            response.Data = record;
            response.Message = "Data found in the database.";
            response.Success = true;

            return response;
        }

        response.Data = null;
        response.Message = "Data not found in the database.";
        response.Success = false;
        
        return response;
    }

    public async Task<ServiceResponse<IEnumerable<TEntity>>> GetAllAsync()
    {
        var records = await Table.ToListAsync();
        return new ServiceResponse<IEnumerable<TEntity>>()
        {
            Data = records,
            Message = "Data found in the database.",
            Success = true
        };
    }

    public async Task<ServiceResponse<TEntity>> AddAsync(TEntity entity)
    {
        var response = new ServiceResponse<TEntity>();
        
        await Table.AddAsync(entity);
        var created = await _context.SaveChangesAsync();
        if (created > 0)
        {
            response.Data = entity;
            response.Message = "Data added to the database.";
            response.Success = true;

            return response;
            
        }

        response.Data = null;
        response.Message = "Data not added to the database.";
        response.Success = false;
        
        return response;
    }

    public async Task<ServiceResponse<TEntity>> UpdateAsync(TEntity entity)
    {
        var response = new ServiceResponse<TEntity>();
        
        Table.Update(entity);
        var updated = await _context.SaveChangesAsync();
        if (updated > 0)
        {
            response.Data = entity;
            response.Message = "Data updated in the database.";
            response.Success = true;

            return response;
        }

        response.Data = null;
        response.Message = "Data not updated in the database.";
        response.Success = false;
        
        return response;
    }

    public async Task<ServiceResponse<TEntity>> DeleteAsync(string id)
    {
        var response = new ServiceResponse<TEntity>();
        var record = await Table.FindAsync(id);

        if (record == null)
        {
            response.Data = null;
            response.Message = "Data not found in the database.";
            response.Success = false;
        }

        Table.Remove(record);
        var deleted = await _context.SaveChangesAsync();

        if (deleted > 0)
        {
            response.Data = record;
            response.Message = "Data deleted from the database.";
            response.Success = true;
            return response;
        }

        response.Data = null;
        response.Message = "Data not deleted from the database.";
        response.Success = false;

        return response;
    }
}