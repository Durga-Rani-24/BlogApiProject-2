using BlogApiProject.Domain;


namespace BlogApiProject.Data.Employees;

public interface IEmployeeRepository
{
    Task<Employee> CreateEmployee(Employee employee);
    Task<Employee?> GetByEmail(string email);
    Task<Employee?> GetById(int id);
    Task<List<Employee>> GetAllEmployees();
    Task UpdateEmployee(int id, Employee employee);
    Task DeleteEmployee(int id);
}
