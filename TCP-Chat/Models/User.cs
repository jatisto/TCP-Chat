using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TCP_Chat.Models {
    public class User : IdentityUser {

        // public bool StatusOnline { get; set; }

        public ICollection<Connection> Connections { get; set; }

    }
}