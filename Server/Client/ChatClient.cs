using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public class ChatClient
    {
        private TcpClient client;
        private NetworkStream stream;

        public void ConnectToServer(string ipAddress, int port)
        {
            client = new TcpClient(ipAddress, port);
            stream = client.GetStream();
            Console.WriteLine("Connected to the server.");

            // Start reading messages in the background
            Thread readThread = new Thread(ReadMessages);
            readThread.Start();
            //ReadMessages();
        }

        private void ReadMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Server says: " + message);
            }
        }

        public void SendMessage(ClientMessage clientMessage)
        {
            if (stream != null && stream.CanWrite)
            {
                //string message = $"{clientMessage.ClientName}: {clientMessage.Message} (Sent at: {clientMessage.SentAt})";
                string message = JsonSerializer.Serialize(clientMessage);
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
