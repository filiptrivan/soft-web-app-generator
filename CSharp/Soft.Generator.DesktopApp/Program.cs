using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Soft.Generator.DesktopApp.Controllers;
using Soft.Generator.DesktopApp.Pages;
using Soft.Generator.DesktopApp.Pages.FrameworkPages;
using Soft.Generator.DesktopApp.Services;
using System;
using System.Windows.Forms.Design;

namespace Soft.Generator.DesktopApp
{
    // TODO NEXT: 1. dodaj atribute za many to many primarne kljuceve
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ServiceCollection serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            Application.ThreadException += ThreadExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<PageNavigator>();

            services.AddScoped<SqlConnection>(_ => new SqlConnection(Settings.ConnectionString));
            services.AddScoped<DesktopAppBusinessService>();
            services.AddScoped<ClientSharedService>();
            services.AddScoped<ValidationService>();

            services.AddScoped<WebApplicationController>();
            services.AddScoped<CompanyController>();
            services.AddScoped<FrameworkController>();
            services.AddScoped<HomeController>();
            services.AddScoped<DomainFolderPathController>();
            services.AddScoped<PermissionController>();
            services.AddScoped<SettingController>();

            services.AddTransient<Form1>();
        }

        static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"{e.Exception.Message}");
        }

        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}