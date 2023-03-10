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
        private List<Thread> msgHandlers = new List<Thread>();
        private List<TcpClient> _clients = new List<TcpClient>();
        private List<Lobby> _lobbies = new List<Lobby>();
        public int ActiveConnectionsCount => _clients.Count;
        public List<TcpClient> Clients => _clients;
        public List<Lobby> Lobbies => _lobbies;
        public TCPServer()
        {
            InitServer();
        }
        private void InitServer()
        {
            server = new TcpListener(IPAddress.Any, 8888); //Server listens for connection attempts on host IP at port 8888
            server.Start();
            Console.WriteLine("Server has been started on " + IPAddress.Any.ToString()); //Server started on host IP
            CommandHandler.InitHandler(this);
            connectionHandler = new Thread(HandleClientConnection);
            connectionHandler.Start();
        }
        private async void HandleClientConnection()
        {
            while (true)
            {
                var tcpClient = await server.AcceptTcpClientAsync(); //Tcp client is the accepted connection request
                Console.WriteLine($"Connection: {tcpClient.Client.RemoteEndPoint}");
                _clients.Add(tcpClient);

                Thread msgHandler = new Thread(() => HandleClientMsgs(tcpClient));
                msgHandler.Name = tcpClient.Client.RemoteEndPoint.ToString();
                msgHandler.Start();
                msgHandlers.Add(msgHandler);
            }
        }
        private async void HandleClientMsgs(TcpClient client)
        {
            try
            {
                var stream = client.GetStream();
                while (true)
                {
                    var buffer = new byte[1024];
                    int received = await stream.ReadAsync(buffer, 0, 1024);

                    var message = Encoding.UTF8.GetString(buffer, 0, received); //Decode sequence of bytes to a message
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
        public async void SendMsgToClient(TcpClient client, string msg) //After sending message to server, server has to send message back to other client
        {
            try
            {
                var stream = client.GetStream();
                byte[] byteMsg = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(byteMsg, 0, byteMsg.Length); //Send message
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cant send message to {client.Client.RemoteEndPoint}\nwith err: {e.Message}");
            }
        }
        public void CreateLobby(TcpClient lobbyHost, string lobbyName)
        {
            Lobby lobby = new Lobby(this, lobbyHost, lobbyName); //Create new lobby
            Console.WriteLine($"Created Lobby {lobbyName} by {lobbyHost.Client.RemoteEndPoint}");
            _lobbies.Add(lobby); //Add lobby to lobby list
        }
        public string[] GetLobbies()
        {
            return _lobbies.FindAll(x => !x.isStarted).Select(x => x.lobbyName).ToArray(); //Find lobbies that have been created but have not started
        }
    }
}
