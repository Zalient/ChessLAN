namespace ChessServer
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new TCPServer(); //Start server
            Console.ReadKey();
        }
    }
}