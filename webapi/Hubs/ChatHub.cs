﻿using Microsoft.AspNetCore.SignalR;

namespace webapi.Hubs;

public class ChatHub : Hub
{
    private readonly string _botUser;
    private  IDictionary<string, UserConnection> _userConnections;
    
    public ChatHub(IDictionary<string, UserConnection> userConnections)
    {
        _botUser = "Bot";
        _userConnections = userConnections;
        // Console.WriteLine(_userConnections.User);
    }

    public async Task SendMessage(string user, string message)//this may not be working properly
    {
        // Console.WriteLine(_userConnections);//issue with sendmessage is because userConnection isnt what we want
        Console.WriteLine($"sent message[");
        Console.WriteLine(message);
        Console.WriteLine("]poggers");
        // Console.WriteLine(_userConnections);
        try {//the issue is something with _userconnect as it never passes if.
            Console.WriteLine("poggers2");
            foreach (string key in _userConnections.Keys) {
                Console.WriteLine(key);
            }
            foreach (UserConnection value in _userConnections.Values) {
                Console.WriteLine(value.User);
                Console.WriteLine(value.Room);
            }
            if (_userConnections.TryGetValue(Context.ConnectionId, out var userConnection))
            {
                Console.WriteLine($"in if sent message:");
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
        Console.WriteLine($"Joined Room2");
        await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
        _userConnections[Context.ConnectionId] = userConnection;
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