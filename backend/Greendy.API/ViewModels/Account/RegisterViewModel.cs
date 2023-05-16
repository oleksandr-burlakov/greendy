using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.API.ViewModels.Account
{
    public record RegisterViewModel(string FirstName, string LastName,
        string Username, string Password, string Email, string? PhoneNumber = null);
}