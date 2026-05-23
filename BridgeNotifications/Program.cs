using BridgeNotifications.Senders;
using BridgeNotifications.Notification;



INotificationSender emailSender = new EmailSender();
Notification alert = new AlertNotification(emailSender);

alert.Send("buy some bread for breakfast");



