﻿using Application.Dtos.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_PostAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController(IAdminService adminService,
                              IUserService userService) : ControllerBase
{
    private readonly IAdminService _adminService = adminService;
    private readonly IUserService _userService = userService;

    [HttpPost("id")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> ChangeUserRoleAsync(int id)
    {
        await _adminService.ChangeUserRoleAsync(id);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> UpdateUserAsync(int id, [FromForm] UpdateUserDto dto)
    {
        await _userService.UpdateAsync(id, dto);
        return Ok();
    }

    [HttpGet("admins")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> GetAllAdminAsync()
        => Ok(await _adminService.GetAllAdminAsync());
}