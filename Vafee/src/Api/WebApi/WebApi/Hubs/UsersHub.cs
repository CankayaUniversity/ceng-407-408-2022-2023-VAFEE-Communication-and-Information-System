using System.Security.Claims;
using Api.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

public class UsersHub : Hub
{
    
    private static IDictionary<string, string> _onlineUsers = new Dictionary<string, string>();

    public UsersHub(UserManager<User> userManager)
    {
        
    }

    public override Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        var userId = Context.User.Identity;

        // _onlineUsers.Add(userId, connectionId);

        // var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }
}