using Microsoft.AspNetCore.SignalR;

namespace webapi.Hubs;

public class ChatHub : Hub
{
    private const string _botUser = "Bot";
    private readonly IDictionary<string, UserConnection> _userConnections;
    
    public ChatHub(IDictionary<string, UserConnection> userConnections)
    {
        _userConnections = userConnections;
    }

    public async Task SendMessage(string message)
    {
        if (_userConnections.TryGetValue(Context.ConnectionId, out var userConnection))
        {
            await Clients.Group(userConnection.Room)
                .SendAsync("ReceiveMessage", userConnection.User, message);
        }
    }

    public async Task JoinRoom(UserConnection userConnection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
        await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser,
            $"{userConnection.User} has joined the room {userConnection.Room}");
        await SendConnectedUsers(userConnection.Room);
    }

    public Task SendConnectedUsers(string room)
    {
        var users = _userConnections.Values.Where(x => x.Room == room).Select(x => x.User);
        return Clients.Group(room).SendAsync("UsersInRoom", users);
    }
    
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        if (_userConnections.TryGetValue(Context.ConnectionId, out var userConnection))
        {
            _userConnections.Remove(Context.ConnectionId);
            Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser,
                $"{userConnection.User} has left the room {userConnection.Room}");
            SendConnectedUsers(userConnection.Room);
        }

        return base.OnDisconnectedAsync(exception);
    }
}