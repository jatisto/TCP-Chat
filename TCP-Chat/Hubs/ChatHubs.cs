using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using TCP_Chat.Date;
using TCP_Chat.Models;

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

        public async Task SendMessage (string user, string to, string message) {

            var userResult = _context.Users.Where (a => a.Id != to);

            await Clients.Caller.SendAsync ("ReceiveMessage", user + ":" + message);
            await Clients.Others.SendAsync ("ReceiveMessage", to + ":" + message);

            await Clients.All.SendAsync ("ReceiveMessage", user, to, message);
        }

    }
}