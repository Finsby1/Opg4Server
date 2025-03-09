using System.Net.Sockets;

namespace Opg4;

public class ClientHandler
{
            public static void HandleClient(TcpClient client)
        {
            Console.WriteLine(client.Client.RemoteEndPoint);
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);
            
            
            bool isRunning = true;
            
            while (isRunning)
            {
                string? message = reader.ReadLine();
                Console.WriteLine(message);
                if (message == "Random")
                {
                    writer.WriteLine("Input numbers");
                    writer.Flush();
                    
                    string? numbers = reader.ReadLine();
                    if (!string.IsNullOrEmpty(numbers))
                    {
                        string[] nrs = numbers.Split(' ');
                        if (nrs.Length == 2 && int.TryParse(nrs[0], out int min) && int.TryParse(nrs[1], out int max))
                        {
                            Random rnd = new Random();
                            int number = rnd.Next(min, max + 1);
                            writer.WriteLine(number);
                            writer.Flush();
                        }
                    }
                }

                else if (message == "Close")
                {
                    writer.WriteLine("Connection Closing");
                    writer.Flush();
                    isRunning = false;
                }
                
                else if (message == "Add")
                {
                    writer.WriteLine("Input numbers");
                    writer.Flush();
                    
                    string? numbers = reader.ReadLine();
                    if (!string.IsNullOrEmpty(numbers))
                    {
                        string[] nrs = numbers.Split(' ');
                        if (nrs.Length == 2 && int.TryParse(nrs[0], out int nr1) && int.TryParse(nrs[1], out int nr2))
                        {
                            writer.WriteLine(nr1 + nr2);
                            writer.Flush();
                        }
                    }
                }
                
                else if (message == "Subtract")
                {
                    writer.WriteLine("Input numbers");
                    writer.Flush();
                    
                    string? numbers = reader.ReadLine();
                    if (!string.IsNullOrEmpty(numbers))
                    {
                        string[] nrs = numbers.Split(' ');
                        if (nrs.Length == 2 && int.TryParse(nrs[0], out int nr1) && int.TryParse(nrs[1], out int nr2))
                        {
                            writer.WriteLine(nr1 - nr2);
                            writer.Flush();
                        }
                    }
                }
            }
        }

}