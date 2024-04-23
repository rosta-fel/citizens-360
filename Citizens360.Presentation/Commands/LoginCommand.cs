using System.Windows;
using Citizens360.Presentation.WindowModels;

namespace Citizens360.Presentation.Commands;

public class LoginCommand : CommandBase
{
    private readonly LoginWindowModel _viewModel;

    public LoginCommand(LoginWindowModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Execute(object? parameter)
    {
        bool isAuthenticated = _viewModel.TryAuth();

        MessageBox.Show(isAuthenticated
            ? "Authentication successful!"
            : "Authentication failed. Please check your username and password.");
    }
}