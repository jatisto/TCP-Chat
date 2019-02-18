namespace TCP_Chat.ViewModels {
    public class SortViewModel {
        public SortState NameSort { get; private set; } // значение для сортировки по имени
        public SortState DateSort { get; private set; } // значение для сортировки по компании
        public SortState Current { get; private set; } // текущее значение сортировки

        public SortViewModel (SortState sortOrder) {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            DateSort = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            Current = sortOrder;
        }
    }
}