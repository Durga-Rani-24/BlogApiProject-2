using BlogApiProject.Application.Employees;
using BlogApiProject.Application.Employees.Dto;
using BlogApiProject.Application.Roles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiProject.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeApplication _employeeApplication;

    public EmployeeController(IEmployeeApplication employeeApplication)
    {
        _employeeApplication = employeeApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateEmployeeDto input)
    {
        try
        {
            var id = await _employeeApplication.CreateEmployee(input);
            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task Put(int id, UpdateEmployeeDto input)
    {
        await _employeeApplication.UpdateEmployee(id, input);
    }

    [HttpGet]
    public async Task<List<EmployeeDto>> GetAllEmployees()
    {
        return await _employeeApplication.GetAllEmployees();
    }

    [HttpGet("{id}")]
    public async Task<EmployeeDto> GetById(int id)
    {
        return await _employeeApplication.GetById(id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteEmployee(int id)
    {
        await _employeeApplication.DeleteEmployee(id);
    }
}
