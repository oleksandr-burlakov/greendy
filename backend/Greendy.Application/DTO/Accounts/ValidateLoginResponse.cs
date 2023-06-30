namespace Greendy.Application.DTO.Accounts;
public record ValidateLoginResponse(bool IsValid, string Username, string Role);