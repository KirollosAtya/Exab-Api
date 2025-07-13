using Exab.Test.Domain.Constants;
using Exab.Test.Domain.Entities.UserManagement;

namespace Exab.Test.Infrastructure.Persistence.Configurations.UserMangementConfigration;
public class RolePermissionConfigration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(rc => rc.ClaimType).IsRequired();
        builder.Property(rc => rc.ClaimValue).IsRequired();

        builder.HasOne(rc => rc.Role)
               .WithMany(r => r.Claims)
               .HasForeignKey(rc => rc.RoleId);
        builder.Property(rp => rp.Resource).IsRequired().HasMaxLength(50);
        builder.Property(rp => rp.Action).IsRequired().HasMaxLength(50);
        builder.Property(rp => rp.Permission).IsRequired().HasMaxLength(100);
        var permisions = Permissions.GetAllPermissions();
        for (int i = 0; i < permisions.Count; i++)
        {

        }

    }
}
