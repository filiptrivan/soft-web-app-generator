using Soft.Generator.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Reflection;

namespace Soft.Generator.Shared.Shared
{
    public static class Helpers
    {
        public static T Request<T>(RequestBody requestBody)
            where T : class
        {
            MethodBase methodInfo = new StackTrace().GetFrame(1).GetMethod();
            string className = methodInfo.ReflectedType.Name;
            requestBody.ControllerName = className;
            requestBody.MethodName = methodInfo.Name;

            T result = null;

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 1000); // Loopback stands for localhost

            using Socket client = new Socket(
                ipEndPoint.AddressFamily, // IPv4 or IPv6
                SocketType.Stream,
                ProtocolType.Tcp
            );

            client.Connect(ipEndPoint); // Establish connection with the server

            try
            {
                while (true)
                {
                    string json = JsonSerializer.Serialize(requestBody);
                    byte[] messageBytes = Encoding.UTF8.GetBytes(json);
                    client.Send(messageBytes, SocketFlags.None);

                    byte[] buffer = new byte[2048]; // FT: If we put smaller buffer exception could be thrown
                    int received = client.Receive(buffer, SocketFlags.None);

                    if (received != 0)
                    {
                        string response = Encoding.UTF8.GetString(buffer, 0, received);
                        if (response.StartsWith("Greška:"))
                        {
                            throw new Exception(response);
                        }
                        result = JsonSerializer.Deserialize<T>(response);
                        break;
                    }
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine($"Socket error during Receive: {se.Message}");
            }
            finally
            {
                try
                {
                    client.Shutdown(SocketShutdown.Both); // SocketShutdown.Both stops both sending and receiving operations.
                }
                catch { /* Ignore shutdown errors if already closed */ }
            }

            return result;
        }

        public static void Request(RequestBody requestBody)
        {
            MethodBase methodInfo = new StackTrace().GetFrame(1).GetMethod();
            string className = methodInfo.ReflectedType.Name;
            requestBody.ControllerName = className;
            requestBody.MethodName = methodInfo.Name;

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
                    if (response.StartsWith("Greška:"))
                    {
                        throw new Exception(response);
                    }
                    break;
                }
            }

            client.Shutdown(SocketShutdown.Both); // SocketShutdown.Both stops both sending and receiving operations.
        }

    }
}
