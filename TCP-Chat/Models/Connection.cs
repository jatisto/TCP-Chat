using System;

namespace TCP_Chat.Models {
    public class Connection {
        public string ConnectionID { get; set; }
        public string UserAgent { get; set; }
        public bool Connected { get; set; }
        public DateTimeOffset LastActivity { get; set; }
    }
}