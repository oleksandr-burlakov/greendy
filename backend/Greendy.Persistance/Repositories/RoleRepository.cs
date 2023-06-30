using Greendy.Application.Repositories;
using Greendy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greendy.Persistance.Repositories;
public class RoleRepository : IRoleRepository
{
    private readonly GreendyContext _context;
    public RoleRepository(GreendyContext context)
    {
       _context = context; 
    }
    public async Task<Role> GetByNameAsync(string name)
    {
        return await _context.Roles.SingleAsync(r => r.Name == name);
    }

    public async Task<Role> GetUserRoleAsync(Guid userId)
    {
        return (await _context.UserRoles.FirstOrDefaultAsync(r => r.UserId == userId))?.Role;
    }
}
