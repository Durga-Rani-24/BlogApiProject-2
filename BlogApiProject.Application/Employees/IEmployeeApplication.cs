

using BlogApiProject.Application.Employees.Dto;

namespace BlogApiProject.Application.Employees;

public interface IEmployeeApplication
{
    Task<int> CreateEmployee(CreateEmployeeDto input);
    //Task GetByEmail(string email);

    Task<LoginResponseDto> LoginAsync(LoginDto dto);

    
}
