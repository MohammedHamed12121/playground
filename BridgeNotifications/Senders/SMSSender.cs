using BridgeNotifications.Senders;

namespace BridgeNotifications.Senders
{
    public class SMSSender: INotificationSender
    {
        public void Send(string title, string message)
        {
            Console.WriteLine($"\t SMS \t");
            Console.WriteLine($"|\t {title} \t|");
            Console.WriteLine($"|\t {message} \t|");
        }
    }
}