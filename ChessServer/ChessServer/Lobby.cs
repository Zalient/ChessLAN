using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessServer
{
    public class Lobby
    {
        private TCPServer _server;
        public LobbyMember player1;
        public LobbyMember player2;
        public bool isStarted;
        public readonly string lobbyName;
        public readonly int lobbyId;

        public Lobby(TCPServer server, TcpClient player1, string lobbyName, int lobbyId)
        {
            this._server = server;
            this.player1 = new LobbyMember(player1, PieceColour.White);
            this.lobbyName = lobbyName;
            this.lobbyId = lobbyId;
            this.isStarted = false;
        }
        public void SecondPlayerConnect(TcpClient player2)
        {
            this.player2 = new LobbyMember(player2, PieceColour.Black);
            isStarted = true;

            _server.SendMessageToClient(player1.tcpClient, "Started");
            _server.SendMessageToClient(player2, "Started");
        }
        public void MoveHandler(TcpClient tcpClient, string from, string to)
        {
            var sender = tcpClient == player1.tcpClient ? player1 : player2;
            var receiver = sender == player1 ? player2 : player1;

            _server.SendMessageToClient(receiver.tcpClient, $"Move {from} {to}");
        }
        public void GameOverHandler(TcpClient tcpClient)
        {
            var sender = tcpClient == player1.tcpClient ? player1 : player2;
            var receiver = sender == player1 ? player2 : player1;
        }
    }
}
