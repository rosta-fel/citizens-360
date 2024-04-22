using System.Windows;
using Citizens360.Application.Services;
using Citizens360.Data;
using Citizens360.Presentation.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Citizens360.Presentation;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private static readonly IHost Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration((_, config) =>
        {
            config.AddJsonFile("app-settings.json", optional: false, reloadOnChange: true);
        })
        .ConfigureServices((context, services) =>
        {
            string? connectionString = context.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<Citizens360Context>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            
            services.AddSingleton<LoginWindow>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        })
        .Build();

    protected override void OnStartup(StartupEventArgs e)
    {
        Host.Start();
        Host.Services.GetRequiredService<LoginWindow>().Show();
        
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Host.StopAsync().Wait();
        
        base.OnExit(e);
    }
}