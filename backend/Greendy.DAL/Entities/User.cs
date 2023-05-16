using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Greendy.Common.Helpers;
using Greendy.DAL.Exceptions.User;

namespace Greendy.DAL;

public partial class User
{
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? UserName { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string PasswordHash { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public virtual ICollection<TrackStorageSubscription> TrackStorageSubscriptions { get; set; } = new List<TrackStorageSubscription>();

    public virtual ICollection<TrackStorage> TrackStorages { get; set; } = new List<TrackStorage>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UserTrackItem> UserTrackItems { get; set; } = new List<UserTrackItem>();

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
        Salt = salt;
        PasswordHash = HashHelper.EncryptPassword(password, Salt);
    }

    public bool CheckPassword(string password)
    {
        byte[] bytes = Salt;
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
