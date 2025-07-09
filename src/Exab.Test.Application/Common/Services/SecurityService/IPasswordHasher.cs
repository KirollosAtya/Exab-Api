namespace Exab.Test.Application.Common.Services.SecurityService;
public  interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}
