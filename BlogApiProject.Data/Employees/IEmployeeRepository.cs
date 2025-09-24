using BlogApiProject.Domain;


namespace BlogApiProject.Data.Employees;

public interface IEmployeeRepository
{
    Task<Employee> CreateEmployee(Employee employee);
    Task<Employee?> GetByEmail(string email);
}
