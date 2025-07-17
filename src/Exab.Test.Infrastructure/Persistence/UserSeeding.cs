using Exab.Test.Application.Common.Services.SecurityService;
using Exab.Test.Domain.Entities.UserManagement;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Exab.Test.Infrastructure.Persistence;
public   static class UserSeeding
{
    public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
    {
        var db = serviceProvider.GetRequiredService<TestDbContext>();
        var hasher = serviceProvider.GetRequiredService<IPasswordHasher>();


        if (!db.Users.Any())
        {
            var users = new[]
            {
            new User
            {

                Username = "admin",
                Email = "admin@example.com",
                PhoneNumber = "0100000000",
                phoneConfirmed = true,
                EmailConfirmed = true,
                IsActive = true,
                PasswordHash = hasher.HashPassword("Admin@123")
            },
                new User
            {
                
                Username = "Manager",
                Email = "manager@example.com",
                PhoneNumber = "0200000000",
                phoneConfirmed = true,
                EmailConfirmed = true,
                IsActive = true,
                PasswordHash = hasher.HashPassword("Manager@123")
            },new User
            {

                Username = "User",
                Email = "user@example.com",
                PhoneNumber = "0300000000",
                phoneConfirmed = true,
                EmailConfirmed = true,
                IsActive = true,
                PasswordHash = hasher.HashPassword("User@123")
            }

        };

            db.Users.AddRange(users);
        

            await db.SaveChangesAsync();
        }
    }
}
