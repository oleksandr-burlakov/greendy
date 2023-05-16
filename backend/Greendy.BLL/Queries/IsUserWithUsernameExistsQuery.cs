using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Greendy.BLL.Queries
{
    public class IsUserWithUsernameExistsQuery : IRequest<bool>
    {
        public string Username {get; set;}
        public IsUserWithUsernameExistsQuery(string username)
        {
            Username = username;
        }
    }
}