using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces;

namespace Citizens360.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public Employee? Get(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Employee ID must be greater than zero.");

        return _unitOfWork.Employees.Get(id);
    }

    public IEnumerable<Employee?> Get()
    {
        return _unitOfWork.Employees.Get();
    }

    public void Create(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), "Employee object cannot be null.");

        _unitOfWork.Employees.Create(employee);
        _unitOfWork.Commit();
    }

    public void Delete(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), "Employee object cannot be null.");

        _unitOfWork.Employees.Delete(employee);
        _unitOfWork.Commit();
    }

    public void Update(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), "Employee object cannot be null.");

        _unitOfWork.Employees.Update(employee);
        _unitOfWork.Commit();
    }
}