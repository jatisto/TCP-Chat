using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCP_Chat.Models;

namespace TCP_Chat.ViewModels {
    public class FilterViewModel {
        public FilterViewModel (List<HistoryLog> historyLog, string date, string namefrom, string nameto) {
            // устанавливаем начальный элемент, который позволит выбрать всех
            historyLog.Insert (0, new HistoryLog { UserFromId = "Отправители", UserToId = "Получатель", Id = null });
            SelectedNameFrom = namefrom;
            SelectedNameTo = nameto;
        }

        public string SelectedNameFrom { get; private set; }   
        public string SelectedNameTo { get; private set; } 
        public string SelectedDate { get; private set; }
    }
}