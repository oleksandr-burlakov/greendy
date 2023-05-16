using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greendy.BLL.Queries;
using Greendy.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Greendy.BLL.Handlers
{
    public class IsUserWithUsernameExistsHandler : IRequestHandler<IsUserWithUsernameExistsQuery, bool>
    {
        private readonly GreendyContext _context;
        public IsUserWithUsernameExistsHandler(GreendyContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(IsUserWithUsernameExistsQuery request, CancellationToken cancellationToken)
        {
            var isUserWithUsernameExists = await _context
                .Users
                .AnyAsync(u => u.UserName == request.Username);
            return isUserWithUsernameExists;
        }
    }
}