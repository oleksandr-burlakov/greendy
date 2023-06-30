using System.Net.Mail;
using Greendy.Common.Helpers;
using Greendy.Domain.Entities;

namespace Greendy.Domain.Extensions;
public static class UserExtensions 
{
    public static bool CheckPassword(this User user, string password)
    {
        byte[] bytes = user.Salt;
        var newPasswordHash = HashHelper.EncryptPassword(password, bytes);
        return newPasswordHash == user.PasswordHash;
    }

    public static bool ValidateEmail(this User user, string email) {
        try {
            MailAddress adress = new(email);
            return true;
        } catch (FormatException) {
            return false;
        }
    }
}
