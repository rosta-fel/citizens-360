using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Citizens360.Presentation.WindowModels;

public abstract class WindowModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}