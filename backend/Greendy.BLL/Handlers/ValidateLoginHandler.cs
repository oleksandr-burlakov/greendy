using Greendy.BLL.Exceptions;
using Greendy.BLL.Queries;
using Greendy.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Greendy.BLL.Handlers
{
    public class ValidateLoginHandler : IRequestHandler<ValidateLoginQuery, ValidateLoginResponse>
    {
        private readonly GreendyContext _context;
        public ValidateLoginHandler(GreendyContext context)
        {
            _context = context;
        }
        public async Task<ValidateLoginResponse> Handle(ValidateLoginQuery request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserName == request.Login || u.Email == request.Login) ?? throw new UserNotExistsException("User with this login doesn't exists");
            if (!user.CheckPassword(request.Password)) {
                throw new IncorrectPasswordException("Password is incorrect");
            }
            var role = user.UserRoles.Select(ur => ur.Role.Name).First();
            return new ValidateLoginResponse(user.UserName!, role);
        }
    }
}
