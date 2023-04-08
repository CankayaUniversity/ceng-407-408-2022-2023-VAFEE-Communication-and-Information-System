using System.Security.Claims;
using Api.Domain.Models.Identity;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebApi.Hubs;

public class UsersHub : Hub
{

    private static IDictionary<string, string> _onlineUsers = new Dictionary<string, string>();
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsersHub(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        var userId = Context.User.Identity;
        var accessToken = _httpContextAccessor.HttpContext.Request.Headers.Authorization;
        var json = JsonConvert.SerializeObject(Context.User);
        // _onlineUsers.Add(userId, connectionId);
        // var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        await Clients.Caller.SendAsync("userJoined", userId, json);
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }
}