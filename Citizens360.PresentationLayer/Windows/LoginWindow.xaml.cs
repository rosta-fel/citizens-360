using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Appearance;

namespace Citizens360.PresentationLayer.Windows;

/// <summary>
///     Interaction logic for LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
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
        SunnySymbolIcon.Filled = !SunnySymbolIcon.Filled;
        ApplicationThemeManager.Apply(SunnySymbolIcon.Filled ? ApplicationTheme.Dark : ApplicationTheme.Light);
    }
}