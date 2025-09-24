

using BlogApiProject.Application.Employees.Dto;
using BlogApiProject.Data.Employees;
using BlogApiProject.Domain;
namespace BlogApiProject.Application.Employees
{
    public class EmployeeApplication: IEmployeeApplication
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
              
              
    }
}
