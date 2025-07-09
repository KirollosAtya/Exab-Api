using System.Security.Claims;

namespace Exab.Test.Domain.Entities.UserManagement;
public  class User : BaseEntity
{
    public string? Username { get; set; } 
    public string? PasswordHash { get; set; } 
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool phoneConfirmed { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool IsActive { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
