

namespace Exab.Test.Domain.Entities.UserManagement;
public  class Role: BaseEntity
{
    public string Name { get; set; } = default!;
    public virtual ICollection<UserRole> UserRoles { get; set; } = [];
}
