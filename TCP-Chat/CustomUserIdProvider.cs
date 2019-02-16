using Microsoft.AspNetCore.SignalR;

namespace TCP_Chat {
    public class CustomUserIdProvider : IUserIdProvider {
        public virtual string GetUserId (HubConnectionContext connection) {
            
            return connection.User?.Identity.Name;
            // или так
            //return connection.User?.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}