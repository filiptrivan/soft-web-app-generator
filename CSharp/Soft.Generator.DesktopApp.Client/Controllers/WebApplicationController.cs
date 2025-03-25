using Spider.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Spider.DesktopApp.Client.Controllers
{
    public class WebApplicationController
    {
        public WebApplication SaveWebApplication(WebApplication webApplication)
        {
            throw new NotImplementedException();
        }

        public void DeleteWebApplication(long id)
        {
            return;
        }

        public List<WebApplication> GetWebApplicationList()
        {
            throw new NotImplementedException();
        }

        public T GetRequest<T>(GetRequestBody getRequestBody)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 1000); // Loopback stands for localhost

            using Socket client = new(
                ipEndPoint.AddressFamily, // IPv4 or IPv6
                SocketType.Stream,
                ProtocolType.Tcp
            );

            client.Connect(ipEndPoint); // Establish connection with the server

            while (true)
            {
                string json = JsonSerializer.Serialize(getRequestBody);
                byte[] messageBytes = Encoding.UTF8.GetBytes(json);
                client.Send(messageBytes, SocketFlags.None);

                // Receive ack.
                byte[] buffer = new byte[1_024];
                int received = client.Receive(buffer, SocketFlags.None);
                string response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    Console.WriteLine(
                        $"Socket client received acknowledgment: \"{response}\"");
                    break;
                }
                // Sample output:
                //     Socket client sent message: "Hi friends 👋!<|EOM|>"
                //     Socket client received acknowledgment: "<|ACK|>"
            }

            client.Shutdown(SocketShutdown.Both); // SocketShutdown.Both stops both sending and receiving operations.

            throw new NotImplementedException();
        }

        public class GetRequestBody
        {
            public string ControllerName { get; set; }
            public List<string> Args { get; set; }
        }

        public WebApplication GetWebApplication(long id)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanyList()
        {
            throw new NotImplementedException();
        }

        public List<Setting> GetSettingList()
        {
            throw new NotImplementedException();
        } 

        public List<DllPath> GetDllPathList()
        {
            throw new NotImplementedException();
        }

        public List<DllPath> GetDllPathListForTheWebApplication(long webApplicationId)
        {
            throw new NotImplementedException();
        }

        public void GenerateNetAndAngularStructure(long webApplicationId)
        {
            return;
        }

        public void GenerateBusinessFiles(long webApplicationId)
        {
            return;
        }
    }
}
