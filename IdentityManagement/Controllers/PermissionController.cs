using IdentityManagement.Constants;
using IdentityManagement.Seed;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagement.Controllers;

[Authorize(Roles = "SuperAdmin")]
public class PermissionController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public PermissionController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<ActionResult> SetPermissions(string roleId, List<string> permissions)
    {
        var role = await _roleManager.FindByIdAsync(roleId);

        foreach (var perm in permissions)
        {
            await _roleManager.AddPermissionClaim(role, perm);
        }

        return Ok();
    }
}