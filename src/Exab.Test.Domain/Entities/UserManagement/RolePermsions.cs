namespace Exab.Test.Domain.Entities.UserManagement;
public  class RolePermission : BaseEntity
{
    public int RoleId { get; set; }
    public Role Role { get; set; } = default!;

    public string ClaimType { get; set; } = string.Empty;
    public string ClaimValue { get; set; } = string.Empty;
}
