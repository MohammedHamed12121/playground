using BridgeNotifications.Senders;
namespace BridgeNotifications.Senders
{
    public class EmailSender : INotificationSender
    {
        public void Send(string title, string message)
        {
            Console.WriteLine($"\t Email \t");
            Console.WriteLine($"|=> {title}");
            Console.WriteLine($"|=> {message}");
        }
    }
}