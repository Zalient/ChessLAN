using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessServer
{
    public class Commands
    {
        private TCPServer _server;
        public Commands(TCPServer server)
        {
            _server = server;
        }
        [ClientCommand("Move")]
        public void Move(TcpClient sender, string from, string to)
        {
            var lobby = _server.Lobbies.Find(x => x.player1.tcpClient == sender || x.player2.tcpClient == sender); //Both players in same lobby
            lobby.MoveHandler(sender, from, to);
        }
        [ClientCommand("GetLobbies")]
        public void GetLobbies(TcpClient sender)
        {
            _server.SendMsgToClient(sender, $"Lobbies {string.Join("|", _server.GetLobbies())}");
        }
        [ClientCommand("CreateLobby")]
        public void CreateLobby(TcpClient sender, string name)
        {
            _server.CreateLobby(sender, name);
        }
        [ClientCommand("ConnectLobby")]
        public void ConnectLobby(TcpClient sender, string name)
        {
            var lobby = _server.Lobbies.Find(x => x.lobbyName == name); //Find lobby that matches the name that second player wishes to connect to
            if (lobby.isStarted) //Cannot join a full lobby
            {
                return;
            }
            lobby.SecondPlayerConnect(sender); //Second player joins lobby 
        }
    }
    public class ClientCommandAttribute : Attribute
    {
        public string Command { get; }
        public ClientCommandAttribute(string command) { Command = command; }
    }
}
