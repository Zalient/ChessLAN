namespace ChessServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServer server = new TCPServer();
            Console.ReadKey();
        }
    }
}