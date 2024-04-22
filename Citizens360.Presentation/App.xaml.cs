using System.Windows;
using Citizens360.Data;
using Citizens360.Presentation.Configuration;
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
            config.AddJsonFile(AppSettings.ConfigFileName, optional: false, reloadOnChange: true);
        })
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<AppSettings>(_ =>
            {
                IConfiguration configuration = context.Configuration;
                return AppSettings.Load(configuration) ?? throw new InvalidOperationException("Failed to load app settings.");
            });
            
            string? connectionString = context.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<Citizens360DbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            
            services.AddSingleton<LoginWindow>();
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