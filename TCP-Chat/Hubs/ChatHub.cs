using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using TCP_Chat.Date;
using TCP_Chat.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace TCP_Chat.Hubs {

    [Authorize]
    public class ChatHub : Hub {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public ChatHub (
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            AppDbContext context) {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task Send (string message, string to) {
            var userName = Context.User.Identity.Name;
            var userId = _context.Users.FirstOrDefault (u => u.UserName == userName);
            var userToId = _context.Users.FirstOrDefault (u => u.UserName == to);

            if (Context.UserIdentifier != to) // если получатель и текущий пользователь не совпадают
                await Clients.User (Context.UserIdentifier).SendAsync ("Receive", message, userName);
            await Clients.User (to).SendAsync ("Receive", message, userName);

            HistoryLog hLog = new HistoryLog () {
                Context = message,
                UserFromId = userId.Id,
                UserToId = userToId.Id,
                Date = DateTimeOffset.UtcNow,
                Status = true                
            };
            _context.Add(hLog);
            await _context.SaveChangesAsync();
        }

        public override async Task OnConnectedAsync () {
            await Clients.All.SendAsync ("Notify", $"Приветствуем {Context.UserIdentifier}");
            await base.OnConnectedAsync ();
        }

        string groupname = "cats";
        public async Task Enter (string username) {
            if (String.IsNullOrEmpty (username)) {
                await Clients.Caller.SendAsync ("Notify", "Для входа в чат введите логин");
            } else {
                await Groups.AddToGroupAsync (Context.ConnectionId, groupname);
                await Clients.Group (groupname).SendAsync ("Notify", $"{username} вошел в чат");
            }
        }
        public async Task SendGroup (string message, string username) {
            await Clients.Group (groupname).SendAsync ("Receive", message, username);
        }

        // public async Task Send (string message, string userName) {
        //     await Clients.All.SendAsync ("Receive", message, userName);
        // }

        // public async Task Send (string message, string userName) {
        //     await Clients.All.SendAsync ("Receive", message, userName);
        // }

        // [Authorize (Roles = "User")]
        // public async Task Notify (string message, string userName) {
        //     await Clients.All.SendAsync ("Receive", message, userName);
        // }

    }
}