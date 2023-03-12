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

        public Lobby(TCPServer server, TcpClient player1, string lobbyName)
        {
            this._server = server;
            this.player1 = new LobbyMember(player1, PieceColour.White); //Player 1 plays as White
            this.lobbyName = lobbyName;
            this.isStarted = false;
        }
        public void SecondPlayerConnect(TcpClient player2)
        {
            this.player2 = new LobbyMember(player2, PieceColour.Black); //Player 2 plays as Black
            isStarted = true;

            _server.SendMsgToClient(player1.tcpClient, "Started");
            _server.SendMsgToClient(player2, "Started"); //Game starts on both devices
        }
        public void MoveHandler(TcpClient tcpClient, string previousMove, string newMove)
        {
            var sender = tcpClient == player1.tcpClient ? player1 : player2; //If tcp client is player 1's then they sent the move
            var receiver = sender == player1 ? player2 : player1; //If sender player 1 then receiver must be player 2

            _server.SendMsgToClient(receiver.tcpClient, $"Move {previousMove} {newMove}"); //Send move to receiver's client
        }
    }
}
