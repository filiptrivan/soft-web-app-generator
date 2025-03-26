using Soft.Generator.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Soft.Generator.Shared.Shared
{
    public static class Helpers
    {
        public static T Request<T, TRequestType>(TRequestType requestBody) 
            where T : class
            where TRequestType : class
        {
            T result = null;

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 1000); // Loopback stands for localhost

            using Socket client = new(
                ipEndPoint.AddressFamily, // IPv4 or IPv6
                SocketType.Stream,
                ProtocolType.Tcp
            );

            client.Connect(ipEndPoint); // Establish connection with the server

            while (true)
            {
                string json = JsonSerializer.Serialize(requestBody);
                byte[] messageBytes = Encoding.UTF8.GetBytes(json);
                client.Send(messageBytes, SocketFlags.None);

                // Receive ack.
                byte[] buffer = new byte[1_024];
                int received = client.Receive(buffer, SocketFlags.None);

                if (received != 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, received);
                    result = JsonSerializer.Deserialize<T>(response);
                    break;
                }
            }

            client.Shutdown(SocketShutdown.Both); // SocketShutdown.Both stops both sending and receiving operations.

            return result;
        }

    }
}
