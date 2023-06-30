using Greendy.Domain.Entities;

namespace Greendy.Application.Repositories;
public interface IRoleRepository 
{
    Task<Role> GetByNameAsync(string name);
    Task<Role> GetUserRoleAsync(Guid userId);
}
