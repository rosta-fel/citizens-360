using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces;

namespace Citizens360.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork? _unitOfWork;

    public EmployeeService(IUnitOfWork? unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public bool Authenticate(string? username, string? password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return false;

        Employee? employee = _unitOfWork?.Employees.GetEmployeeByUsername(username);

        return employee != null && employee.Password == password;
    }
}