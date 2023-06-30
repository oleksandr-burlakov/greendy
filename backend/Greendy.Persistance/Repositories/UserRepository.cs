using Greendy.Application.Repositories;
using Greendy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greendy.Persistance.Repositories;
public class UserRepository : IUserRepository
{
    private readonly GreendyContext _context;
    public UserRepository(GreendyContext context)
    {
        _context = context;   
    }

    public async Task<Guid> AddAsync(User user)
    {
        var returnValue = (await _context.Users.AddAsync(user)).Entity.UserId;
        await _context.SaveChangesAsync();
        return returnValue;
    }

    public async Task<User?> GetByLoginAsync(string login)
    {
        var user = await _context
                .Users
                .FirstOrDefaultAsync(u => u.UserName == login);
        return user;
    }
}
