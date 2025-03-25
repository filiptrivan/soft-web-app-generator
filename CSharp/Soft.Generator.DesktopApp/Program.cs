using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Soft.Generator.DesktopApp
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 1000);

            using Socket listener = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            listener.Bind(ipEndPoint);
            listener.Listen(100);

            Socket handler = listener.Accept();

            while (true)
            {
                // Receive message.
                byte[] buffer = new byte[1_024];
                int received = handler.Receive(buffer, SocketFlags.None);
                string response = Encoding.UTF8.GetString(buffer, 0, received);

                string eom = "<|EOM|>";
                if (response.IndexOf(eom) > -1 /* is end of message */)
                {
                    Console.WriteLine(
                        $"Socket server received message: \"{response.Replace(eom, "")}\"");

                    string ackMessage = "<|ACK|>";
                    byte[] echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                    handler.Send(echoBytes, 0);
                    Console.WriteLine(
                        $"Socket server sent acknowledgment: \"{ackMessage}\"");
                }
                // Sample output:
                //    Socket server received message: "Hi friends 👋!"
                //    Socket server sent acknowledgment: "<|ACK|>"
            }
        }
    }
}