using Citizens360.Application.Services;
using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces.Repositories;
using Moq;

namespace Citizens360.Application.Test.Services;

[TestFixture]
public class EmployeeServiceTests
{
    [Test]
    public void Get_ValidId_ReturnsEmployee()
    {
        // Arrange
        const int employeeId = 1;
        Employee expectedEmployee = new() { Id = employeeId, FirstName = "John", LastName = "Doe" };
        Mock<IEmployeeRepository> mockRepository = new();
        mockRepository.Setup(repo => repo.Get(employeeId)).Returns(expectedEmployee);
        EmployeeService employeeService = new(mockRepository.Object);

        // Act
        Employee? result = employeeService.Get(employeeId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedEmployee));
    }

    [Test]
    public void Get_AllEmployees_ReturnsAllEmployees()
    {
        // Arrange
        List<Employee> expectedEmployees =
        [
            new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" },
            new Employee { Id = 3, FirstName = "Michael", LastName = "Johnson" }
        ];
        Mock<IEmployeeRepository> mockRepository = new();
        mockRepository.Setup(repo => repo.Get()).Returns(expectedEmployees.AsQueryable());
        EmployeeService employeeService = new(mockRepository.Object);

        // Act
        IEnumerable<Employee?> result = employeeService.Get();

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedEmployees));
    }

    [Test]
    public void Create_NewEmployee_CreatesEmployee()
    {
        // Arrange
        Mock<IEmployeeRepository> mockRepository = new();
        EmployeeService employeeService = new(mockRepository.Object);
        Employee newEmployee = new() { FirstName = "John", LastName = "Doe" };

        // Act
        employeeService.Create(newEmployee);

        // Assert
        mockRepository.Verify(repo => repo.Create(newEmployee), Times.Once);
    }

    [Test]
    public void Delete_ExistingEmployee_DeletesEmployee()
    {
        // Arrange
        const int employeeId = 1;
        Mock<IEmployeeRepository> mockRepository = new();
        EmployeeService employeeService = new(mockRepository.Object);

        // Act
        employeeService.Delete(new Employee { Id = employeeId });

        // Assert
        mockRepository.Verify(repo => repo.Delete(It.IsAny<Employee>()), Times.Once);
    }

    [Test]
    public void Update_ExistingEmployee_UpdatesEmployee()
    {
        // Arrange
        Mock<IEmployeeRepository> mockRepository = new();
        EmployeeService employeeService = new(mockRepository.Object);
        Employee existingEmployee = new() { Id = 1, FirstName = "John", LastName = "Doe" };

        // Act
        employeeService.Update(existingEmployee);

        // Assert
        mockRepository.Verify(repo => repo.Update(existingEmployee), Times.Once);
    }
}