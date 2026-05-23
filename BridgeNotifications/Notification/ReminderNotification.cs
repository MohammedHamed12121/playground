using BridgeNotifications.Senders;
namespace BridgeNotifications.Notification
{
    public class ReminderNotification : Notification
    {
        public ReminderNotification(INotificationSender sender) : base(sender)
        {
        }

        public override void Send(string message)
        {
            sender.Send(
                title: "Reminder",
                message: $"Remeber to {message}"
            );
        }
    }
}