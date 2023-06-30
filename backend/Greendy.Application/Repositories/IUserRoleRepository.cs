using Greendy.Domain.Entities;

namespace Greendy.Application.Repositories;
public interface IUserRoleRepository 
{
    Task AddAsync(UserRole userRole);
}
