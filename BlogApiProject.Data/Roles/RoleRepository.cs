using BlogApiProject.Domain;

namespace BlogApiProject.Data.Roles;

public class RoleRepository : IRoleRepository
{
    private readonly DataContext _context;
    
    // ------ constructor for Role repository2 -----
    // ------ constructor for Role repository8 -----
    public RoleRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<Role?> GetById(int id)
    {
        return await _context.Roles.FindAsync(id);
    }
}
