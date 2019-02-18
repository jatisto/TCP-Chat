using System;
using System.Collections.Generic;
using TCP_Chat.Models;

namespace TCP_Chat.ViewModels {
    public class HistoryLogVM {
        public IEnumerable<HistoryLog> HistoryLogs { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}