using Greendy.Domain.Extensions;
using Greendy.Common.Helpers;
using Greendy.Domain.Exceptions;

namespace Greendy.Domain.Entities;

public partial class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? UserName { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null;

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
        if (!this.ValidateEmail(email)) {
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
}
