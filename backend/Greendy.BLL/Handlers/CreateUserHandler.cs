using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greendy.BLL.Commands;
using Greendy.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Greendy.BLL.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly GreendyContext _context;
		private readonly ILogger<CreateUserHandler> _logger;
        public CreateUserHandler(GreendyContext context, ILogger<CreateUserHandler> logger)
        {
			_logger = logger;
            _context = context;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new(request.FirstName,
                request.LastName, request.UserName, request.Password,
                request.Email, request.PhoneNumber);
            Role role = await _context.Roles.SingleAsync(r => r.Name == request.Role);
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                user = (await _context.Users.AddAsync(user)).Entity;
                UserRole userRole = new()
                {
                    RoleId = role.RoleId,
                    UserId = user.UserId
                };
				
                await _context.UserRoles.AddAsync(userRole);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
				_logger.LogError(default(EventId), ex, ex.Message);
                throw;
            }
            return user.UserId;
        }
    }
}
