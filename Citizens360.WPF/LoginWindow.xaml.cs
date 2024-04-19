using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Wpf.Ui.Appearance;

namespace Citizens360.WPF;

/// <summary>
///     Interaction logic for LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void SetLanguage(string? language)
    {
        if(string.IsNullOrWhiteSpace(language)) return;
        
        CultureInfo culture = new(language);
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
        
        foreach (UIElement element in LogicalTreeHelper.GetChildren(this).OfType<UIElement>())
        {
            element.InvalidateMeasure();
            element.InvalidateArrange();
            element.InvalidateVisual();
        }
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

    private void ModeSwitcherButton_OnClick(object sender, RoutedEventArgs e)
    {
        SunnySymbolIcon.Filled = !SunnySymbolIcon.Filled;
        ApplicationThemeManager.Apply(SunnySymbolIcon.Filled ? ApplicationTheme.Dark : ApplicationTheme.Light);
    }

    private void MenuItemUS_OnClick(object sender, RoutedEventArgs e)
    {
        SetLanguage(MenuItemUs.Tag.ToString());
    }

    private void MenuItemCZ_OnClick(object sender, RoutedEventArgs e)
    {
        SetLanguage(MenuItemCz.Tag.ToString());
    }
}