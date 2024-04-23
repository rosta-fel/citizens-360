using System.Windows.Input;
using Citizens360.Application.Services;
using Citizens360.Presentation.Commands;

namespace Citizens360.Presentation.WindowModels;

public class LoginWindowModel : WindowModelBase
{
    private readonly IEmployeeService _employeeService = App.GetRequiredService<IEmployeeService>();
    private ICommand? _loginCommand;
    
    private string? _username;
    private string? _password;

    public ICommand LoginCommand => _loginCommand ??= new LoginCommand(this);

    public string? Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    public string? Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public bool TryAuth()
    {
        return _employeeService.Authenticate(Username, Password);
    }
}