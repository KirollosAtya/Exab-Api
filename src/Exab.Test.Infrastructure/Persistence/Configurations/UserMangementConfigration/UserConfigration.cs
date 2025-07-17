using Exab.Test.Domain.Entities.UserManagement;

namespace Exab.Test.Infrastructure.Persistence.Configurations.UserMangementConfigration;

public class UserConfigration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Username).IsRequired().HasMaxLength(250);

        builder.Property(c => c.PasswordHash).IsRequired().HasMaxLength(500);

        builder.HasIndex(u => u.Username).IsUnique();

        builder
          .HasMany(u => u.UserRoles)
          .WithOne(ur => ur.User)
          .HasForeignKey(ur => ur.UserId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}