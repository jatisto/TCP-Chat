using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TCP_Chat.Hubs {
    public class ChatHubs : Hub {

        public async Task SendMessage (string user, string to, string message) {
            await Clients.All.SendAsync ("ReceiveMessage", user, to, message);
        }

    }
}