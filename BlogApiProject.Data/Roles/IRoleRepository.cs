using BlogApiProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApiProject.Data.Roles
{
    public interface IRoleRepository
    {
        Task<Role> CreateRole(Role role);        
        Task<Role?> GetById(int id);
        Task<List<Role>> GetAllRoles();
        Task UpdateRole(int id, Role role);
        Task DeleteRole(int id);

    }
}
