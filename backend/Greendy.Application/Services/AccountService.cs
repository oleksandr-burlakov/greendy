using Greendy.Application.DTO.Accounts;
using Greendy.Application.Interfaces;
using Greendy.Application.Repositories;
using Greendy.Domain.Entities;
using Greendy.Domain.Extensions;

namespace Greendy.Application.Services;
public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    public AccountService(IUserRepository userRepository, 
        IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository)
    {
       _userRepository = userRepository; 
       _roleRepository = roleRepository;
       _userRoleRepository = userRoleRepository;
    }
    public async Task<bool> CheckUserExistanceAsync(string username)
    {
        var user = await _userRepository.GetByLoginAsync(username);
        return user != null;
    }

    public async Task<Guid> RegisterAsync(RegisterAccountRequest request)
    {
        var user = new User(request.FirstName, request.LastName, request.UserName,
            request.Password, request.Email, request.PhoneNumber);
        var id = await _userRepository.AddAsync(user);
        var role = await _roleRepository.GetByNameAsync(request.Role);
        UserRole userRole = new()
        {
            RoleId = role.RoleId,
            UserId = user.UserId
        };
        await _userRoleRepository.AddAsync(userRole);
        return id;
    }

    public async Task<ValidateLoginResponse> ValidateLoginAsync(string login, string password)
    {
        var user = await _userRepository.GetByLoginAsync(login) ?? throw new Exception("User not found");
        var isValid = user.CheckPassword(password);
        var role = await _roleRepository.GetUserRoleAsync(user.UserId);
        return new ValidateLoginResponse(isValid, user.UserName, role.Name);
    }
}
