namespace Greendy.Application.DTO.Accounts;

public record RegisterAccountRequest(string FirstName, string LastName,
        string UserName, string Password, string Email, string? PhoneNumber = null,
        string Role = "User");