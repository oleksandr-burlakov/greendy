using MediatR;

namespace Greendy.BLL.Commands
{
    public record CreateUserCommand(string FirstName, string LastName,
        string UserName, string Password, string Email, string? PhoneNumber = null,
        string Role = "User")
        : IRequest<Guid>;
}
