using Exab.Test.Domain.Constants;
using Exab.Test.Domain.Entities.UserManagement;
using System.Security.Claims;

namespace Exab.Test.Application.Common.Services.AuthicationService;
public class JwtProvider : IJwtProvider
{
   
   private readonly JwtSettings _jwtSettings;

    public JwtProvider(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

   

    public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new SecurityTokenException("Invalid token");
        }
        var principal = new JwtSecurityTokenHandler()
            .ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _jwtSettings.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret!)),
                    ValidAudience = _jwtSettings.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                },
                out var validatedToken);
        return (principal, validatedToken as JwtSecurityToken);
    }

    public (string token, int expeireIn) GenerateTokens(User user)
    {
        List<Claim> claims = new()
                            {
                                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                                new Claim(JwtRegisteredClaimNames.Name, user.Username!),
                                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                                new Claim(JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber!)
                            };

        var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
        var permissions = user.UserRoles
        .SelectMany(ur => ur.Role.Claims)
        .Select(rp => rp.Permission)
        .Distinct()
        .ToList();
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        
        claims.AddRange(permissions.Select(p => new Claim("permission", p)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims.ToArray(),
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiration),
            signingCredentials: creds
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), _jwtSettings.AccessTokenExpiration);

    }
}
