using gspark.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class AdminController : BaseController
{
    private readonly UserManager<User> _userManager;

    public AdminController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    
    [Authorize(Policy = "AdminRole")]
    [HttpGet("get-roles")]
    public async Task<IActionResult> GetUserRoles()
    {
        var users = await _userManager.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .Select(u => new
            {
                u.Id,
                Username = u.UserName,
                Role = u.UserRoles.Select(r => r.Role.Name).ToList()
            }).ToListAsync();
        
        return Ok(users);
    }

    [Authorize(Roles = "AdminRole")]
    [HttpPost("edit-roles/{username}")]
    public async Task<IActionResult> EditUserRoles([FromQuery] string roles, string username)
    {
        var selectedRoles = roles.Split(",").ToArray();
        var user = await _userManager.FindByNameAsync(username);
        if (user == null) return NotFound("Could not find user");
        
        var userRoles = await _userManager.GetRolesAsync(user);

        // Adding new role to user
        var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
        if (!result.Succeeded) return BadRequest("Failed to add roles");

        result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
        if (!result.Succeeded) return BadRequest("Failed to remove roles");

        return Ok(await _userManager.GetRolesAsync(user));
    }
}