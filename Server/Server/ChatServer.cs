using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ChatServer
    {
        public TcpListener tcpListener;
        public List<TcpClient> clients = new List<TcpClient>();

        public void Start(int port)
        { 
            tcpListener = new TcpListener(System.Net.IPAddress.Any, port);
            tcpListener.Start();
            Console.WriteLine("Server started on port " + port);

           Thread acceptThread = new Thread(AcceptClients);
            acceptThread.Start();
        }

        private void AcceptClients(object? obj)
        {
            while (true)
            {
                try
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    clients.Add(client);
                    Console.WriteLine("Client connected: " + client.Client.RemoteEndPoint);

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error accepting client: " + ex.Message);
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received: " + message);

                    // Echo message back to the client
                    byte[] response = Encoding.UTF8.GetBytes("Echo: " + message);
                    stream.Write(response, 0, response.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error communicating with client: " + ex.Message);
            }
            finally
            {
                stream.Close();
                client.Close();
                clients.Remove(client);
                Console.WriteLine("Client disconnected.");
            }
        }
    }
}
