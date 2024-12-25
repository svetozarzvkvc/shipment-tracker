namespace ShipmentTracker.UI.Services
{
    public class FlashMessageService
    {
        public string Message { get; private set; }
        public string CssClass { get; private set; }

        public event Action OnMessageChanged;

        public void SetMessage(string message, string cssClass = "alert-success", int duration = 5000)
        {
            Message = message;
            CssClass = cssClass;
            NotifyMessageChanged();

            if (duration > 0)
            {
                Task.Delay(duration).ContinueWith(_ =>
                {
                    ClearMessage();
                });
            }
        }

        public void ClearMessage()
        {
            Message = null;
            CssClass = null;
            NotifyMessageChanged();
        }

        private void NotifyMessageChanged() => OnMessageChanged?.Invoke();
    }

}
