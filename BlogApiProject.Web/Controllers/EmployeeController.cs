using BlogApiProject.Application.Employees;
using BlogApiProject.Application.Employees.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogApiProject.Web.Controllers;


[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeApplication _employeeApplication;
    private readonly IConfiguration _configuration;

    public EmployeeController(IEmployeeApplication employeeApplication, IConfiguration configuration)
    {
        _employeeApplication = employeeApplication;
        _configuration = configuration;
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

    [HttpPost("login")]
    public async Task<IActionResult> Post(LoginDto input)
    {
        try
        {
            var response = await _employeeApplication.LoginAsync(input);

            var jwtSetting = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF )

            return Ok(new { message = "Login successful", data = response });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
    }
}
