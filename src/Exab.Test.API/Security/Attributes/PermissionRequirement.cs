using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Exab.Test.API.Security.Attributes;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string[] Permission { get; }

    public PermissionRequirement(string[] permission)
    {
        Permission = permission;
    }
}
public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(
         AuthorizationHandlerContext context, PermissionRequirement requirement)
    {

        var userPermissions = context.User.Claims
           .Where(c => c.Type == "permission")
           .Select(c => c.Value)
           .ToHashSet();

        if (requirement.Permission.Any(p => userPermissions.Contains(p)))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail(); 
        }

        return Task.CompletedTask;
    }
}
