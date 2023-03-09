using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChessServer
{
    public class TCPServer
    {
        private TcpListener server;
        private Thread connectionHandler;
        private List<Thread> messageHandlers = new List<Thread>();
        private List<TcpClient> _clients = new List<TcpClient>();
        private List<Lobby> _lobbies = new List<Lobby>();
        public int ActiveConnectionsCount => _clients.Count;
        public List<TcpClient> Clients => _clients;
        public List<Lobby> Lobbies => _lobbies;
        public TCPServer()
        {
            StartServer();
        }
        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 8888);
            server.Start();
            Console.WriteLine("Server has been started on " + IPAddress.Any.ToString());
            CommandHandler.InitCommandHandler(this);
            connectionHandler = new Thread(HandleClientConnection);
            connectionHandler.Start();
        }
        private async void HandleClientConnection()
        {
            while (true)
            {
                var tcpClient = await server.AcceptTcpClientAsync();
                Console.WriteLine($"Connection: {tcpClient.Client.RemoteEndPoint}");
                _clients.Add(tcpClient);

                Thread msgHandler = new Thread(() => HandleMessagesFromClient(tcpClient));
                msgHandler.Name = tcpClient.Client.RemoteEndPoint.ToString();
                msgHandler.Start();
                messageHandlers.Add(msgHandler);
            }
        }
        private async void HandleMessagesFromClient(TcpClient client)
        {
            try
            {
                var stream = client.GetStream();
                while (true)
                {
                    var buffer = new byte[1024];
                    int received = await stream.ReadAsync(buffer, 0, 1024);

                    var message = Encoding.UTF8.GetString(buffer, 0, received);
                    Console.WriteLine($"Message received: \"{message}\" from: {client.Client.RemoteEndPoint}");
                    CommandHandler.Handler(message, client);
                }
            }
            catch
            {
                Console.WriteLine(client.Client.RemoteEndPoint + " Has been disconnected");
                _clients.Remove(client);
            }
        }
        public async void SendMessageToClient(TcpClient client, string msg)
        {
            try
            {
                var stream = client.GetStream();
                byte[] byteMsg = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(byteMsg, 0, byteMsg.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cant send message to {client.Client.RemoteEndPoint}\nwith err: {e.Message}");
            }
        }
        public void CreateLobby(TcpClient creator, string name)
        {
            Lobby newLobby = new Lobby(this, creator, name, _lobbies.Count);
            Console.WriteLine($"Created Lobby {name} by {creator.Client.RemoteEndPoint}");
            _lobbies.Add(newLobby);
        }

        public string[] GetAvailableLobbies()
        {
            return _lobbies.FindAll(x => !x.isStarted).Select(x => x.lobbyName).ToArray();
        }
    }
}
