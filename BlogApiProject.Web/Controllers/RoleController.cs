using BlogApiProject.Application.Roles;
using BlogApiProject.Application.Roles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiProject.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleApplication _roleApplication;
    public RoleController(IRoleApplication roleApplication)
    {
        _roleApplication = roleApplication;
    }

    [HttpPost]
    public async Task<int> Post(CreateUpdateRoleDto input)
    {
        var data = await _roleApplication.CreateRole(input);
        return data.Id;
    }

    [HttpGet]
    public async Task<List<RoleDto>> GetAllRoles()
    {
        return await _roleApplication.GetAllRoles();
    }

    [HttpGet("{id}")]
    public async Task<RoleDto> GetById(int id)
    {
        return await _roleApplication.GetById(id);
    }

    [HttpPut("{id}")]
    public async Task Put(int id, CreateUpdateRoleDto input)
    {
        await _roleApplication.UpdateRole(id,input);
    }

    [HttpDelete("{id}")]
    public async Task DeleteRole(int id)
    {
        await _roleApplication.DeleteRole(id);
    }

}
