using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Greendy.BLL.Queries
{
    public record ValidateLoginQuery (string Login, string Password) : IRequest<ValidateLoginResponse>;
    public record ValidateLoginResponse (string Username, string Role);
}