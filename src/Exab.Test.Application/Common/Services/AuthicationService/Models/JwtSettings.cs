namespace Exab.Test.Application.Common.Services.AuthicationService.Models;
public class JwtSettings
{
    public string? Secret { get; set; }
    public string? Issuer { get; set; }
    public string Audience { get; set; } = null!;
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifeTime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public int AccessTokenExpiration { get; set; }
    public int RefreshTokenExpiration { get; set; }
}