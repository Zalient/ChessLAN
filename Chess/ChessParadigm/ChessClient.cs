﻿using System;
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
        public PieceColour myColour;
        public bool IsConnected { get { return tcpClient != null && tcpClient.Connected; } }
        private string waitMsg;
        public async Task<bool> Connect(string ip)
        {
            try
            {
                tcpClient = new TcpClient();
                Console.WriteLine("Client started");
                await tcpClient.ConnectAsync(ip, 8888);

                if (!tcpClient.Connected)
                    return false;

                Console.WriteLine($"Connection with {tcpClient.Client.RemoteEndPoint} established");

                receiveMsgThread = new Thread(ServerMessageHandler);
                receiveMsgThread.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async void ServerMessageHandler()
        {
            try
            {
                var stream = tcpClient.GetStream();
                while (true)
                {
                    var buffer = new byte[1_024];
                    int received = await stream.ReadAsync(buffer, 0, 1024);

                    var message = Encoding.UTF8.GetString(buffer, 0, received);
                    waitMsg = message;
                    Console.WriteLine($"Message received: \"{message}\"");

                    if (message == "Started")
                    {
                        GameForm form = new GameForm();
                        Application.Run(form);
                    }
                    if (message.Contains("Move"))
                    {
                        string[] splittedMsg = message.Split(' ');
                        KeyValuePair<int, int> previousMove = Board.Instance.NotationToCoordinates(splittedMsg[1]);
                        KeyValuePair<int, int> newMove = Board.Instance.NotationToCoordinates(splittedMsg[2]);
                        Cell pieceCell = Board.Instance.Cells[previousMove.Key, previousMove.Value];
                        Cell targetCell = Board.Instance.Cells[newMove.Key, newMove.Value];
                        Board.Instance.Move_Piece(pieceCell, targetCell);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private async Task<string> WaitForMessageResponse(string msg)
        {
            waitMsg = "";
            Console.WriteLine("WAITNULL");
            SendMessageToServer(msg);
            while (waitMsg == "")
            {
                await Task.Delay(25);
            }
            Console.WriteLine("WAITED");
            return waitMsg;
        }
        public async void SendMessageToServer(string msg)
        {
            try
            {
                var stream = tcpClient.GetStream();
                byte[] byteMsg = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(byteMsg, 0, byteMsg.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cant send message to server\nwith err: {e.Message}");
            }
        }
        public void CreateLobby(string name)
        {
            SendMessageToServer($"CreateLobby {name}");
            myColour = PieceColour.White;
        }
        public void ConnectLobby(string name)
        {
            SendMessageToServer($"ConnectLobby {name}");
            myColour = PieceColour.Black;
        }
        public async Task<List<string>> GetLobbies()
        {
            string response = await WaitForMessageResponse("GetLobbies");
            Console.WriteLine(response);
            return new List<string>(response.Split(' ')[1].Split('|'));
        }
    }
}