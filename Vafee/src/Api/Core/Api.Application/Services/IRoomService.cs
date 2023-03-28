using System.Linq.Expressions;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Domain.Models;

namespace Api.Application.Services;

public interface IRoomService
{
    IQueryable<GetRoomDto> GetAllRooms();
    Task<IQueryable<GetRoomDto>> GetAllRoomsWhereAsync(Expression<Func<Room, bool>> expression);
    Task<GetRoomDto> GetRoomByIdAsync(string roomId);

    Task<bool> RemoveRoomAsync(string roomId);
    Task<bool> RemoveRoomAsync(Room room);
    Task<bool> RemoveAllRoomsWhereAsync(Expression<Func<Room, bool>> expression);

    Task<bool> AddRoomAsync(CreateRoomDto room);
    Task<bool> AddRoomsAsync(IEnumerable<CreateRoomDto> rooms);
}