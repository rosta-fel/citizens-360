using System.Windows;
using Citizens360.Application.Services;
using Citizens360.Presentation.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Citizens360.Presentation;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private static readonly IHost Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<LoginWindow>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }).Build();

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