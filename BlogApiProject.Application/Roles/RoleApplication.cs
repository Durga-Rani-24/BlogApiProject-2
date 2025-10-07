using BlogApiProject.Application.Roles.Dto;
using BlogApiProject.Data.Roles;
using BlogApiProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApiProject.Application.Roles
{
    public class RoleApplication : IRoleApplication
    {     
        private readonly IRoleRepository _roleRepository;
        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> CreateRole(CreateUpdateRoleDto input)
        {
            var role = new Role();
            role.Name = input.Name;
            role.CreatedDate = DateTime.Now;
            role.UpdatedDate = DateTime.Now;

            var result = await _roleRepository.CreateRole(role);

            var roleDto = new RoleDto();
            roleDto.Id = result.Id;
            roleDto.Name = result.Name;
            roleDto.CreatedAt = result.CreatedDate;
            roleDto.UpdatedAt = result.UpdatedDate;
            return roleDto;
        }
        public async Task UpdateRole(int id, CreateUpdateRoleDto input)
        {
            var role = await _roleRepository.GetById(id);

            role.Name = input.Name;
            role.UpdatedDate = DateTime.Now;

            await _roleRepository.UpdateRole(id, role);
            
        }

       
        public async Task<string> DeleteRole(int id)
        {
            await _roleRepository.DeleteRole(id);
            return "Deleted";
        }

        public async Task<List<RoleDto>> GetAllRoles()
        {
            var data = await _roleRepository.GetAllRoles();
            var roles = data.Select(x=> new RoleDto() 
            {
                Id = x.Id, 
                Name = x.Name,
                CreatedAt = x.CreatedDate,
                UpdatedAt=x.UpdatedDate,
            }).ToList();

            return roles;
        }

        public async Task<RoleDto> GetById(int id)
        {
            var result = await _roleRepository.GetById(id);

            if(result == null)
            {
                throw new Exception("Id is not available");
            }
            var data = new RoleDto()
            {
                Id = result.Id,
                Name = result.Name,
                CreatedAt = result.CreatedDate,
                UpdatedAt = result.UpdatedDate
            };
            return data;
        }

      
    }
}
