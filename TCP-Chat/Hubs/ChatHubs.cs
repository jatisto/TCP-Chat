using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TCP_Chat.Date;
using TCP_Chat.Models;
using TCP_Chat.ViewModels;

namespace TCP_Chat.Hubs {
    public class ChatHubs : Hub {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public ChatHubs (
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            AppDbContext context) {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        // public override Task OnConnectedAsync () {
        //     Clients.All.user (Context.User.Identity.Name);
        //     return base.OnConnectedAsync ();
        // }
        // public void Send (string message) {
        //     Clients.Caller.message ("You: " + message);
        //     Clients.Others.message (Context.User.Identity.Name + ":" + message);
        // }

        // public async Task SendMessage (string user, string to, string message) {
        //     await Clients.All.SendAsync ("ReceiveMessage", user, to, message);
        // }

        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string> ();

        public void SendChatMessage (string who, string message) {
            string name = Context.User.Identity.Name;
            foreach (var connectionId in _connections.GetConnections (who)) {
                Clients.Client (connectionId).SendAsync ("ReceiveMessage", who, message);
            }
        }

        // public override Task OnConnectedAsync () {
        //     string name = Context.User.Identity.Name;

        //     _connections.Add (name, Context.ConnectionId);

        //     return base.OnConnectedAsync ();
        // }

        public override Task OnConnectedAsync () {

            string name = Context.User.Identity.Name;
            if (name == null) {
                return base.OnConnectedAsync ();
            }

            var user = _context.Users
                .Include (u => u.Connections)
                .SingleOrDefault (u => u.UserName == name);

            if (user == null) {
                user = new User {
                UserName = name,
                Connections = new List<Connection> ()
                };

                _context.Add (user);
            } else {
                user.Connections.Add (new Connection {
                    ConnectionID = Context.ConnectionId,
                        LastActivity = DateTimeOffset.UtcNow,
                        Connected = true
                });

                _context.SaveChangesAsync ();
            }
            _connections.Add (name, Context.ConnectionId);

            return base.OnConnectedAsync ();
        }

        public Task SendMessageToAll (string message) {
            return Clients.All.SendAsync ("ReceiveMessage", message);
        }

        public Task SendMessageToCaller (string message) {
            return Clients.Caller.SendAsync ("ReceiveMessage", message);
        }

        public Task SendMessageToUser (string connectionId, string message) {
            return Clients.Client (connectionId).SendAsync ("ReceiveMessage", message);
        }

        // public override async Task OnConnectedAsync () {
        //     await Clients.All.SendAsync ("UserConnected", Context.ConnectionId);
        //     await base.OnConnectedAsync ();
        // }

        public override async Task OnDisconnectedAsync (Exception ex) {

            var connection = _context.Connections.Find (Context.ConnectionId);
            connection.Connected = false;
            await _context.SaveChangesAsync ();
            await base.OnDisconnectedAsync (ex);
        }
    }
}