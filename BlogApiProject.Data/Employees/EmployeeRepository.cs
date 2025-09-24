

using BlogApiProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApiProject.Data.Employees;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;

    public EmployeeRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<Employee> CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> GetByEmail(string email)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}
