using Application.Dtos.LikesDtos;
using Application.Interfaces;
using Date.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_PostAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikesControllers(ILikesService likesService) : ControllerBase
{
    private readonly ILikesService _likesService = likesService;

    [HttpPost, Authorize(Roles = "SuperAdmin,Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AddLikesDto dto)
    {
        await _likesService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _likesService.GetAllAsync());
    }

    [HttpDelete("{id}"), Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _likesService.DeleteAsync(id);
        return Ok();
    }
}
