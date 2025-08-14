namespace HelpDesk_Benedict.Services
{
    public class TicketStateService
    {
        public event Action? OnChange;

        public void NotifyChange() {
            OnChange?.Invoke();
        }
    }
}
