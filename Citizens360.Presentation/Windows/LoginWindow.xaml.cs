using System.Windows;
using System.Windows.Input;
using Citizens360.Presentation.Configuration;
using Wpf.Ui.Appearance;

namespace Citizens360.Presentation.Windows;

/// <summary>
///     Interaction logic for LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    private readonly AppSettings _appSettings;
    
    public LoginWindow(AppSettings appSettings)
    {
        InitializeComponent();
        _appSettings = appSettings;

        Loaded += LoginWindow_Loaded;
        Closing += LoginWindow_Closing;
    }
    
    private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
    {
        UpdateTheme(_appSettings.DarkTheme);
    }
    
    private void LoginWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        _appSettings.Save();
    }
    
    private void TopStackPanel_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void HideWindowButton_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseWindowButton_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ThemeSwitcherButton_OnClick(object sender, RoutedEventArgs e)
    {
        UpdateTheme(!SunnySymbolIcon.Filled);
        _appSettings.DarkTheme = ApplicationThemeManager.GetAppTheme() == ApplicationTheme.Dark;
    }

    private void UpdateTheme(bool isDarkTheme)
    {
        SunnySymbolIcon.Filled = isDarkTheme;
        ApplicationThemeManager.Apply(isDarkTheme ? ApplicationTheme.Dark : ApplicationTheme.Light);
    }
}