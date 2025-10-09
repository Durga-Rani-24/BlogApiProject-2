

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

    public async Task DeleteEmployee(int id)
    {
        var employee = _context.Employees.Find(id);

        if(employee != null)
        {
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetById(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task UpdateEmployee(int id, Employee input)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            employee.Name = input.Name;
            employee.IsEnabled = input.IsEnabled;
            employee.UpdatedAt = DateTime.Now;
            employee.RoleId = input.RoleId;
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
