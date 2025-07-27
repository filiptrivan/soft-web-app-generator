using System.Net.Sockets;
using System.Net;
using System.Text;
using Soft.Generator.Shared.Classes;
using System.Text.Json;
using Soft.Generator.DesktopApp.Controllers;
using Soft.Generator.DesktopApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Soft.Generator.DesktopApp;
using Soft.Generator.DesktopApp.Entities;
using Azure;
using Soft.Generator.Shared.Interfaces;

namespace Soft.Generator.DesktopApp
{
    public class MainClass
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            ControllerPipeService controllerPipeService = ServiceProvider.GetService<ControllerPipeService>();

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 1000);

            using Socket listener = new Socket(
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
                    try
                    {
                        byte[] buffer = new byte[2048]; // FT: If we put smaller buffer exception could be thrown
                        int received = handler.Receive(buffer, SocketFlags.None);

                        if (received == 0)
                        {
                            Console.WriteLine("Client disconnected.");
                            break;
                        }

                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, received);
                        RequestBody getRequestBody = JsonSerializer.Deserialize<RequestBody>(receivedMessage);

                        string response = controllerPipeService.GetResponse(getRequestBody);

                        handler.Send(Encoding.UTF8.GetBytes(response), SocketFlags.None);
                    }
                    catch (Exception ex)
                    {
                        handler.Send(Encoding.UTF8.GetBytes($"Greška: {ex.Message}"), SocketFlags.None);
                        Console.WriteLine($"Socket error during Receive: {ex.Message}");
                        break;
                    }
                }

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                handler.Dispose();
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<SqlConnection>(_ => new SqlConnection(Settings.ConnectionString));
            services.AddScoped<ISqlConnection, SoftSqlConnection>();
            services.AddScoped<DesktopAppBusinessService>();

            services.AddScoped<WebApplicationController>();
            services.AddScoped<CompanyController>();
            services.AddScoped<FrameworkController>();
            services.AddScoped<HomeController>();
            services.AddScoped<DllPathController>();
            services.AddScoped<PermissionController>();
            services.AddScoped<SettingController>();
            services.AddScoped<ControllerPipeService>();
        }
    }
}