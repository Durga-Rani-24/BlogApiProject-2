using BlogApiProject.Domain;


namespace BlogApiProject.Data.Employees;

public interface IEmployeeRepository
{
    Task<Employee> CreateEmployee(Employee employee);
    Task<Employee?> GetByEmail(string email);
    Task<Employee?> LoginAsync(string email, string password);
}
