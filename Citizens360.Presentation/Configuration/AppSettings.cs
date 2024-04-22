using System.IO;
using System.Reflection;
using Citizens360.Presentation.Configuration.Settings;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Citizens360.Presentation.Configuration;

public class AppSettings
{
    public static string ConfigFileName { get; } = "app-settings.json";
    
    public ConnectionStrings? ConnectionStrings { get; init; }
    public string? LanguageTag { get; set; }
    public bool DarkTheme { get; set; }

    public static AppSettings? Load(IConfiguration configuration)
    {
        return configuration.Get<AppSettings>();
    }

    public void Save()
    {
        string exePath = Assembly.GetExecutingAssembly().Location;
        string? directory = Path.GetDirectoryName(exePath);

        if (directory == null) 
            throw new InvalidOperationException("Failed to determine the directory of the executable file.");
        
        string filePath = Path.Combine(directory, ConfigFileName);

        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}