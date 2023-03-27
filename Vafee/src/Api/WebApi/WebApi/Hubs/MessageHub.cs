using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

public class MessageHub:Hub
{
    public override Task OnConnectedAsync()
    {
        
        return base.OnConnectedAsync();
    }


    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}