using Exab.Test.Domain.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Common.Services.AuthicationService.Interfaces;
public  interface IJwtProvider
{
    public string GenerateTokens(User user);
    public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
}
