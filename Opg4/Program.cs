// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using Opg4;

Console.WriteLine("TCP Server");
int port = 7;
TcpListener listener = new TcpListener(
    IPAddress.Any, port);
listener.Start();

while (true)
{
    TcpClient client = listener.AcceptTcpClient();
    Task.Run(() => ClientHandler.HandleClient(client));
}
listener.Stop();