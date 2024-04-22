using Citizens360.Application.Services;
using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces;
using Moq;

namespace Citizens360.Application.Test.Services;

[TestFixture]
public class EmployeeServiceTests
{
    [Test]
    public void Authenticate_ValidCredentials_ReturnsTrue()
    {
        // Arrange
        const string? username = "testUser";
        const string? password = "testPassword";
        Employee expectedEmployee = new() { Username = username, Password = password };

        Mock<IUnitOfWork> mockUnitOfWork = new();
        mockUnitOfWork.Setup(uow => uow.Employees.GetEmployeeByUsername(username)).Returns(expectedEmployee);

        EmployeeService employeeService = new(mockUnitOfWork.Object);

        // Act
        bool isAuthenticated = employeeService.Authenticate(username, password);

        // Assert
        Assert.That(isAuthenticated, Is.True);
    }

    [Test]
    public void Authenticate_EmptyUsername_ReturnsFalse()
    {
        // Arrange
        const string? password = "testPassword";

        EmployeeService employeeService = new(null);

        // Act
        bool isAuthenticated = employeeService.Authenticate("", password);

        // Assert
        Assert.That(isAuthenticated, Is.False);
    }

    [Test]
    public void Authenticate_EmptyPassword_ReturnsFalse()
    {
        // Arrange
        const string? username = "testUser";

        EmployeeService employeeService = new(null);

        // Act
        bool isAuthenticated = employeeService.Authenticate(username, "");

        // Assert
        Assert.That(isAuthenticated, Is.False);
    }

    [Test]
    public void Authenticate_NullUsername_ReturnsFalse()
    {
        // Arrange
        const string? password = "testPassword";

        EmployeeService employeeService = new(null);

        // Act
        bool isAuthenticated = employeeService.Authenticate(null, password);

        // Assert
        Assert.That(isAuthenticated, Is.False);
    }

    [Test]
    public void Authenticate_NullPassword_ReturnsFalse()
    {
        // Arrange
        const string? username = "testUser";

        EmployeeService employeeService = new(null);

        // Act
        bool isAuthenticated = employeeService.Authenticate(username, null);

        // Assert
        Assert.That(isAuthenticated, Is.False);
    }
}