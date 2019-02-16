using System;
using TCP_Chat.Models;

namespace TCP_Chat.Models {
    public class HistoryLog : Entity {
        public string UserToId { get; set; }
        public User UserTo { get; set; }

        public string UserFromId { get; set; }
        public User UserFrom { get; set; }
        public string Context { get; set; }
        public DateTimeOffset Date { get; set; }
        public bool Status { get; set; }
    }
}