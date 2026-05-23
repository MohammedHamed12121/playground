using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgeNotifications.Senders
{
    public interface INotificationSender
    {
        void Send(string title, string message);
    }
}