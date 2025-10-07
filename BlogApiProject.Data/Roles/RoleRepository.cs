using BlogApiProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApiProject.Data.Roles;

public class RoleRepository : IRoleRepository
{
    private readonly DataContext _context;

    // ------ constructor for Role repository -----
    public RoleRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Role> CreateRole(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<Role?> GetById(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task DeleteRole(int id)
    {
        var role = _context.Roles.Find(id);

        if (role != null)
        {
            _context.Remove(role);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Role>> GetAllRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task UpdateRole(int id, Role input)
    {
        var role = _context.Roles.Find(id);
        if (role != null)
        {
            role.Name = input.Name;
            role.UpdatedDate = DateTime.Now;
            _context.Update(role);
            await _context.SaveChangesAsync();
        }
    }

}
