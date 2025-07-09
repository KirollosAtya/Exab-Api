using Exab.Test.Domain.Entities.UserManagement;

namespace Exab.Test.Infrastructure.Persistence.Configurations.UserMangementConfigration;

public class RoleConfigration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(250);
    }
}
