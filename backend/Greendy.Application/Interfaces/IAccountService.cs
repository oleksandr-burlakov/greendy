using Greendy.Application.DTO.Accounts;

namespace Greendy.Application.Interfaces;
public interface IAccountService 
{
    public Task<ValidateLoginResponse> ValidateLoginAsync(string login, string password);
    public Task<bool> CheckUserExistanceAsync(string username);
    public Task<Guid> RegisterAsync(RegisterAccountRequest request);
}
