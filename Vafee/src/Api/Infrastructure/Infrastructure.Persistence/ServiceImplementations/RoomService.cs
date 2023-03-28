using System.Linq.Expressions;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Application.Services;
using Api.Domain.Models;
using Infrastructure.Persistence.Context;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.ServiceImplementations;

public class RoomService : IRoomService
{
    private readonly VafeeContext _context;
    private readonly IMapper _mapper;

    public RoomService(VafeeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IQueryable<GetRoomDto> GetAllRooms()
    {
        return _context.Rooms.AsNoTrackingWithIdentityResolution().Adapt<IQueryable<GetRoomDto>>();
    }

    public Task<IQueryable<GetRoomDto>> GetAllRoomsWhereAsync(Expression<Func<Room, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<GetRoomDto> GetRoomByIdAsync(string roomId)
    {
        var record = await _context.Rooms.FindAsync(roomId);
        return record?.Adapt<GetRoomDto>();
    }

    public Task<bool> RemoveAllRoomsWhereAsync(Expression<Func<Room, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddRoomAsync(CreateRoomDto room)
    {
        var record = room.Adapt<Room>();
        await _context.Rooms.AddAsync(record);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddRoomsAsync(IEnumerable<CreateRoomDto> rooms)
    {
        var records = rooms.Adapt<IEnumerable<Room>>();
        await _context.Rooms.AddRangeAsync(records);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveRoomAsync(string roomId)
    {
        var roomToDelete = await _context.Rooms.FindAsync(roomId);
        if (roomToDelete == null)
        {
            return false;
        }

        _context.Rooms.Remove(roomToDelete);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveRoomAsync(Room room)
    {
        _context.Rooms.Remove(room);
        return await _context.SaveChangesAsync() > 0;
    }
}