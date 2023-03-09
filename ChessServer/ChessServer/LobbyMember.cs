using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessServer
{
    public enum PieceColour { White, Black }
    public class LobbyMember
    {
        public readonly TcpClient tcpClient;
        public readonly PieceColour colour;

        public LobbyMember(TcpClient tcpClient, PieceColour colour)
        {
            this.tcpClient = tcpClient;
            this.colour = colour;
        }
    }
}
