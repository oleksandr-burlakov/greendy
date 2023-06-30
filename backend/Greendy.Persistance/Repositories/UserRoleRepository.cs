using Greendy.Application.Repositories;
using Greendy.Domain.Entities;

namespace Greendy.Persistance.Repositories;
public class UserRoleRepository : IUserRoleRepository
{
    private readonly GreendyContext _context;
    public UserRoleRepository(GreendyContext context)
    {
        _context = context;   
    }

    public async Task AddAsync(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
        await _context.SaveChangesAsync();
    }
}
