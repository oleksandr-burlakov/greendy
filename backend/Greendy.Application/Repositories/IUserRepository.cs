using Greendy.Domain.Entities;

namespace Greendy.Application.Repositories;

public interface IUserRepository 
{
    public Task<User?> GetByLoginAsync(string login);
    public Task<Guid> AddAsync(User user);
}