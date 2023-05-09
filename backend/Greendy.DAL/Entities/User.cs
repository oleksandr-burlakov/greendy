
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Greendy.Common.Helpers;
using Greendy.DAL.Exceptions.User;

namespace Greendy.DAL.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public User()
        {
        }
        public User(string firstName, string lastName,
            string userName, string password, string email, string? phoneNumber)
        {
            if (!ValidateEmail(email)) {
                throw new InvalidEmailException($"{email} is invalid.");
            }
            UserId = Guid.NewGuid();
            LastModifiedDate = DateTime.UtcNow;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            UserName = userName;

            var salt = HashHelper.GetSalt();
            Salt = Encoding.ASCII.GetString(salt);
            PasswordHash = HashHelper.EncryptPassword(password, salt);
        }

        public bool CheckPassword(string password)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(Salt);
            var newPasswordHash = HashHelper.EncryptPassword(password, bytes);
            return newPasswordHash == PasswordHash;
        }

        private bool ValidateEmail(string email) {
            try {
                MailAddress adress = new(email);
                return true;
            } catch (FormatException) {
                return false;
            }
        }
    }
}