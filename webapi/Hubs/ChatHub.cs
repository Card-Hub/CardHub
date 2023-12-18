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

    public async Task SendMessage(string user, string message)//this may not be working properly
    {
        // Console.WriteLine(_userConnections);//issue with sendmessage is because userConnection isnt what we want
        Console.WriteLine($"sent message");
        foreach (var kvp in _userConnections)
        {
            var connectionId = kvp.Key;
            var userConnection = kvp.Value;

            Console.WriteLine($"ConnectionId: {connectionId}, UserConnection: {userConnection}");
        }
        try {
            if (_userConnections.TryGetValue(Context.ConnectionId, out var userConnection))
            {
                Console.WriteLine($"sent message: {message}");
                await Clients.Group(userConnection.Room)
                    .SendAsync("ReceiveMessage", userConnection.User, message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message: {ex.Message}");
        }

    }

    public async Task JoinRoom(UserConnection userConnection)
    {
        Console.WriteLine($"Joined Room");
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
        if (!_userConnections.TryGetValue(Context.ConnectionId, out var userConnection))
            return base.OnDisconnectedAsync(exception);
        
        _userConnections.Remove(Context.ConnectionId);
        Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser,
            $"{userConnection.User} has left the room {userConnection.Room}");
        SendConnectedUsers(userConnection.Room);

        return base.OnDisconnectedAsync(exception);
    }
}