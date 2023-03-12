using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessClient
    {
        private TcpClient tcpClient;
        private Thread receiveMsgThread;
        public bool IsConnected { get { return tcpClient != null && tcpClient.Connected; } }
        public PieceColour Colour { get; set; }
        private string waitMsg;
        public async Task<bool> Connect(string ip)
        {
            try
            {
                tcpClient = new TcpClient(); //Start client
                await tcpClient.ConnectAsync(ip, 8888);
                if (!tcpClient.Connected)
                {
                    return false;
                }

                //Connection established
                receiveMsgThread = new Thread(ServerMsgHandler);
                receiveMsgThread.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async void ServerMsgHandler()
        {
            try
            {
                var stream = tcpClient.GetStream();
                while (true)
                {
                    var buffer = new byte[1024];
                    int received = await stream.ReadAsync(buffer, 0, 1024);

                    var message = Encoding.UTF8.GetString(buffer, 0, received);
                    waitMsg = message;

                    //Message received from server
                    if (message == "Started")
                    {
                        GameForm form = new GameForm();
                        Application.Run(form);
                        Board.Instance.InitPieces();
                    }
                    if (message.Contains("Move"))
                    {
                        string[] splittedMsg = message.Split(' ');
                        KeyValuePair<int, int> previousMove = Helper.NotationToCoordinates(splittedMsg[1]); //Second component is previous move
                        KeyValuePair<int, int> newMove = Helper.NotationToCoordinates(splittedMsg[2]); //Third component is new move
                        Cell pieceCell = Board.Instance.Cells[previousMove.Key, previousMove.Value];
                        Cell targetCell = Board.Instance.Cells[newMove.Key, newMove.Value];
                        Board.Instance.Move_Piece(pieceCell, targetCell); //Move the pieces at these cells 
                    }
                }
            }
            catch (Exception) { }
        }
        private async Task<string> AwaitMsgResponse(string msg)
        {
            waitMsg = "";
            SendMsgToServer(msg);
            while (waitMsg == "") //Wait until response received from server
            {
                await Task.Delay(25);
            }
            //Waited
            return waitMsg;
        }
        public async void SendMsgToServer(string msg)
        {
            try
            {
                var stream = tcpClient.GetStream();
                byte[] byteMsg = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(byteMsg, 0, byteMsg.Length);
            }
            catch (Exception) { }
        }
        public void CreateLobby(string name)
        {
            Helper.ChessClient = this;
            SendMsgToServer($"CreateLobby {name}");
        }
        public void ConnectLobby(string name)
        {
            Helper.ChessClient = this;
            SendMsgToServer($"ConnectLobby {name}");
        }
        public async Task<List<string>> GetLobbies()
        {
            string response = await AwaitMsgResponse("GetLobbies");
            Console.WriteLine(response);
            return new List<string>(response.Split(' ')[1].Split('|'));
        }
    }
}
