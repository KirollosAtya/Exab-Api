namespace Exab.Test.Domain.Entities.UserManagement;
public  class UserRole :BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;

    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = default!;
}
