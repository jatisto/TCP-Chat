using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using TCP_Chat.Models;

namespace TCP_Chat.Hubs {

    [Authorize]
    public class ChatMyHub : Hub {

        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string> ();

        public void SendChatMessage (string who, string message) {
            string name = Context.User.Identity.Name;

            foreach (var connectionId in _connections.GetConnections (who)) {
                Clients.Client (connectionId).SendAsync (name + ": " + message);
            }
        }

        public override Task OnConnectedAsync () {
            string name = Context.User.Identity.Name;

            _connections.Add (name, Context.ConnectionId);

            return base.OnConnectedAsync ();
        }

        // public override Task OnDisconnected (bool stopCalled) {
        //     string name = Context.User.Identity.Name;

        //     _connections.Remove (name, Context.ConnectionId);

        //     return base.OnDisconnected (stopCalled);
        // }

        // public override Task OnReconnected () {
        //     string name = Context.User.Identity.Name;

        //     if (!_connections.GetConnections (name).Contains (Context.ConnectionId)) {
        //         _connections.Add (name, Context.ConnectionId);
        //     }

        //     return base.OnReconnected ();
        // }

    }
}