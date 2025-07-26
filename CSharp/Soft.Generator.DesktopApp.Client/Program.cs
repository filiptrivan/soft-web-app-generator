using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Soft.Generator.DesktopApp.Client;
using Soft.Generator.DesktopApp.Client.Controllers;
using Soft.Generator.DesktopApp.Client.Pages;
using Soft.Generator.DesktopApp.Client.Pages.FrameworkPages;
using Soft.Generator.DesktopApp.Client.Services;
using Soft.Generator.Shared.Entities;
using System;
using System.Net;
using System.Windows.Forms.Design;

namespace Soft.Generator.DesktopApp
{
    /// <summary>
    /// TODO NEXT: 
    /// - dodaj atribute za many to many primarne kljuceve
    /// - Dodaj logiku za autocomplete i dropdown pri generisanju detalja.html, neces imati problem sa imenovanjem jer ces koristiti od roditelja, o tome kasnije tek treba da se razlimslja kad ubacis odrzavanja many to many i one to many
    /// - Dodaj file with transaction za rad sa fajlovima
    /// 
    /// UPUTSTVO:
    /// - ef core verzije generatora i projekta moraju da se poklapaju
    /// </summary>
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static Company CurrentCompany { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ServiceCollection serviceCollection = new();

            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            Application.ThreadException += ThreadExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<PageNavigator>();

            services.AddScoped<ClientSharedService>();
            services.AddScoped<ValidationService>();

            services.AddScoped<WebApplicationController>();
            services.AddScoped<CompanyController>();
            services.AddScoped<FrameworkController>();
            services.AddScoped<HomeController>();
            services.AddScoped<DllPathController>();
            services.AddScoped<PermissionController>();
            services.AddScoped<SettingController>();

            services.AddTransient<LoginForm>();
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