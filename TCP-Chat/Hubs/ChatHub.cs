using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TCP_Chat.Date;
using TCP_Chat.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace TCP_Chat.Hubs {

    [Authorize]
    public class ChatHub : Hub {

        //Подключает клас ConnectionMapping для добавления и удаления пользователей в сети
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string> ();
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

        //Отправка сообщений
        public async Task Send (string message, string to) {
            var userName = Context.User.Identity.Name;
            var userId = _context.Users.FirstOrDefault (u => u.UserName == userName);
            var userToId = _context.Users.FirstOrDefault (u => u.UserName == to);

            if (Context.UserIdentifier != to) // если получатель и текущий пользователь не совпадают
                await Clients.User (Context.UserIdentifier).SendAsync ("Receive", message, userName);
            await Clients.User (to).SendAsync ("Receive", message, userName);

            // Запись сообщений в Log
            HistoryLog hLog = new HistoryLog () {
                Context = message,
                UserFromId = userId.Id,
                UserToId = userToId.Id,
                Date = DateTimeOffset.UtcNow,
                Status = true
            };
            _context.Add (hLog);
            await _context.SaveChangesAsync ();
        }

        //Пользователи которые подключены
        public override async Task OnConnectedAsync () {
            string name = Context.User.Identity.Name;
            await Clients.All.SendAsync ("Notify", $"Приветствуем {Context.UserIdentifier}");

            if (name == null) {
                await base.OnConnectedAsync ();
            }
            //Поиск User-а
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
                //Добовляем пользователя который подключилья, в базу и на карту подключений
                user.Connections.Add (new Connection {
                    ConnectionID = Context.ConnectionId,
                        LastActivity = DateTimeOffset.UtcNow,
                        Connected = true,
                        Name = name
                });

                await _context.SaveChangesAsync ();
            }
            _connections.Add (name, Context.ConnectionId);
            await base.OnConnectedAsync ();
        }

        //Пользователи которые отключлись
        public override async Task OnDisconnectedAsync (Exception ex) {
            await Clients.All.SendAsync ("NotifyDisconnected", $"Пока {Context.UserIdentifier}");

            //Находим пользователя и меняем ему статус на false и обновляем подключение и удаляем с карты подключений
            var connection = _context.Connections.Find (Context.ConnectionId);
            connection.Connected = false;
            _context.Update (connection);
            await _context.SaveChangesAsync ();

            await base.OnDisconnectedAsync (ex);
        }

        //Устанавливаем имя пользователя
        string groupname = "TCP-Chat";
        public async Task Enter (string username) {

            if (String.IsNullOrEmpty (username)) {
                await Clients.Caller.SendAsync ("Notify", "Для входа в чат введите логин");
            } else {
                await Groups.AddToGroupAsync (Context.ConnectionId, groupname);
                await Clients.Group (groupname).SendAsync ("Notify", $"{username} вошел в чат");
            }
        }
        //Отправка сообщений группе
        public async Task SendGroup (string message, string username) {
            await Clients.Group (groupname).SendAsync ("Receive", message, username);
        }

    }
}