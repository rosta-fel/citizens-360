
namespace Citizens360.Application.Services;

public interface IEmployeeService
{
    bool Authenticate(string? username, string? password);
}