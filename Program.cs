using System.Net.Sockets;
using System.Net;

namespace JSONTCP{
    public class Program{
        static void Main(string[] args){
            int port = 12000;

            Console.WriteLine("Server initialized");

            TcpListener listener = new(IPAddress.Any, port);
            listener.Start();

            while(true){
                TcpClient socket = listener.AcceptTcpClient();

                Console.WriteLine("Client " + socket.Client.RemoteEndPoint + " connected");

                Task.Run(() => TCPServer.HandleClient(socket,port));
            }
        }
    }
}
