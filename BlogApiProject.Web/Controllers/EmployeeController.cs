using BlogApiProject.Application.Employees;
using BlogApiProject.Application.Employees.Dto;
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
}
