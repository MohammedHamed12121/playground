using BridgeNotifications.Senders;
namespace BridgeNotifications.Notification
{
    public abstract class Notification
    {
        protected readonly INotificationSender sender;
        protected Notification(INotificationSender sender)
        {
            this.sender = sender;
        }

        public abstract void Send(string message);
    }
}