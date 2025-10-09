using BlogApiProject.Application.Employees.Dto;
using BlogApiProject.Application.Roles.Dto;
using BlogApiProject.Data.Employees;
using BlogApiProject.Domain;

namespace BlogApiProject.Application.Employees;

public class EmployeeApplication : IEmployeeApplication
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeApplication(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> CreateEmployee(CreateEmployeeDto input)
    {
        var checkEmployee = await _employeeRepository.GetByEmail(input.Email);
        if (checkEmployee != null)
        {
            throw new Exception("Email is already Exists");
        }

        var employee = new Employee();

        employee.Name = input.Name;
        employee.Email = input.Email;
        employee.PasswordHash = input.Password;

        employee.CreatedAt = DateTime.Now;
        employee.RoleId = 4;
        employee.IsEnabled = true;

        var response = await _employeeRepository.CreateEmployee(employee);
        return response.Id;
    }

    public async Task UpdateEmployee(int id, UpdateEmployeeDto input)
    {
        var employee = await _employeeRepository.GetById(id);

        employee.Name = input.Name;
        employee.IsEnabled = input.IsEnabled;
        employee.UpdatedAt = DateTime.Now;
       
        await _employeeRepository.UpdateEmployee(id, employee);
    }

    public async Task<string> DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteEmployee(id);
        return "Deleted";
    }

    public async Task<List<EmployeeDto>> GetAllEmployees()
    {
        var data = await _employeeRepository.GetAllEmployees();
        var employees = data.Select(x => new EmployeeDto()
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            IsEnabled = x.IsEnabled,
        }).ToList();

        return employees;
    }

    public async Task<EmployeeDto> GetById(int id)
    {
        var result = await _employeeRepository.GetById(id);

        if (result == null)
        {
            throw new Exception("Id is not available");
        }
        var data = new EmployeeDto()
        {
            Id = result.Id,
            Name = result.Name,
            IsEnabled = result.IsEnabled,
            CreatedAt = result.CreatedAt,
            UpdatedAt = result.UpdatedAt
        };
        return data;
    }
}
