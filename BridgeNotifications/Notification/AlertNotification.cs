using BridgeNotifications.Senders;
namespace BridgeNotifications.Notification
{
    public class AlertNotification : Notification
    {
        public AlertNotification(INotificationSender sender) : base(sender)
        {
        }

        public override void Send(string message)
        {
            sender.Send(
                title: "Alert",
                message: $"[HIGH PRIORITY] {message}"
            );
        }
        
    }
}