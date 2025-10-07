using BlogApiProject.Application.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApiProject.Application.Roles
{
    public interface IRoleApplication
    {
        Task<RoleDto> CreateRole(CreateUpdateRoleDto role);

        Task<RoleDto> GetById(int id);
        Task<List<RoleDto>> GetAllRoles();

        Task UpdateRole(int id, CreateUpdateRoleDto role);
        Task<string> DeleteRole(int id);

    }
}
