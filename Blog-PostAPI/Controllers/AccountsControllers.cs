﻿using Application.Dtos.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsControllers(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost("registr")]
    [AllowAnonymous]
    public async Task<IActionResult> RegistrAsync([FromForm] AddUserDto dto)
    {
        var result = await _accountService.RegistrAsync(dto);
        return Ok(result);
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
    {
        var result = await _accountService.LoginAsync(dto);
        return Ok($"Token : {result}");
    }
}