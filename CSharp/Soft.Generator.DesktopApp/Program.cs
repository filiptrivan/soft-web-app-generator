using System.Net.Sockets;
using System.Net;
using System.Text;
using Soft.Generator.Shared.Classes;
using System.Text.Json;
using Spider.DesktopApp.Controllers;
using Spider.DesktopApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Spider.DesktopApp;
using Spider.DesktopApp.Entities;

namespace Soft.Generator.DesktopApp
{
    public class MainClass
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 1000);

            using Socket listener = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            listener.Bind(ipEndPoint);
            listener.Listen(100);

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                Socket handler = listener.Accept();
                Console.WriteLine("Client connected.");

                while (true)
                {
                    byte[] buffer = new byte[1_024];
                    int received = handler.Receive(buffer, SocketFlags.None);

                    if (received == 0)
                    {
                        Console.WriteLine("Client disconnected.");
                        break;
                    }

                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, received);
                    GetRequestBody getRequestBody = JsonSerializer.Deserialize<GetRequestBody>(receivedMessage);

                    string response = GetResponse(getRequestBody);

                    byte[] echoBytes = Encoding.UTF8.GetBytes(response);
                    handler.Send(echoBytes, SocketFlags.None);
                }
            }
        }

        private static string GetResponse(GetRequestBody getRequestBody)
        {
            WebApplicationController webApplicationController = ServiceProvider.GetRequiredService<WebApplicationController>();

            string controllerName = getRequestBody.ControllerName;
            string methodName = getRequestBody.MethodName;

            if (controllerName == nameof(WebApplicationController))
            {
                if (methodName == nameof(WebApplicationController.GetWebApplicationList))
                {
                    return JsonSerializer.Serialize(webApplicationController.GetWebApplicationList());
                }
            }

            throw new NotImplementedException($"The controller: {controllerName} and method: {methodName} are not implemented.");
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<SqlConnection>(_ => new SqlConnection(Settings.ConnectionString));
            services.AddScoped<DesktopAppBusinessService>();

            services.AddScoped<WebApplicationController>();
            services.AddScoped<CompanyController>();
            services.AddScoped<FrameworkController>();
            services.AddScoped<HomeController>();
            services.AddScoped<DllPathController>();
            services.AddScoped<PermissionController>();
            services.AddScoped<SettingController>();
        }
    }
}