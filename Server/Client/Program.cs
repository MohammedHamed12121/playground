using Client;

Console.Write("Enter your name: ");
string clientName = Console.ReadLine();

Console.Clear();

Console.WriteLine($"Wellcome {clientName}");

ChatClient client = new ChatClient();
client.ConnectToServer("127.0.0.1", 5000); // Connect to localhost

while(true)
{
    Console.Write("Type a message to send:");
    int promptTop = Console.CursorTop;

    string messageTxt = Console.ReadLine();
    ClientMessage message = new ClientMessage()
    {
        ClientName = clientName,
        Message = messageTxt,
        SentAt = DateTime.Now

    };

    Console.SetCursorPosition(0, promptTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, promptTop);

    client.SendMessage(message);
    Console.WriteLine($"{message.ClientName}: {message.Message} (Sent at: {message.SentAt})");
}