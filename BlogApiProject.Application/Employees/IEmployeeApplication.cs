

using BlogApiProject.Application.Employees.Dto;
using BlogApiProject.Application.Roles.Dto;

namespace BlogApiProject.Application.Employees;

public interface IEmployeeApplication
{
    Task<int> CreateEmployee(CreateEmployeeDto input);
    //Task GetByEmail(string email);

    Task<EmployeeDto> GetById(int id);
    Task<List<EmployeeDto>> GetAllEmployees();

    Task UpdateEmployee(int id, UpdateEmployeeDto updateEmployeeDto);
    Task<string> DeleteEmployee(int id);



}
