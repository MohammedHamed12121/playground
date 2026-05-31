using Client;

ChatClient client = new ChatClient();
client.ConnectToServer("127.0.0.1", 5000); // Connect to localhost

Console.WriteLine("Type a message to send:");
while(true)
{
    string message = Console.ReadLine();
    client.SendMessage(message);
}