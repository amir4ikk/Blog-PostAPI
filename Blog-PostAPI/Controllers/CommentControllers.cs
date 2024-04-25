using Application.Dtos.CommentDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_PostAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentControllers(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService _commentService = commentService;

    [HttpPost, Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddCommentDto dto)
    {
        await _commentService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _commentService.GetAllAsync());
    }

    [HttpGet("{id}"), Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _commentService.GetByIdAsync(id));
    }

    [HttpDelete("{id}"), Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _commentService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut, Authorize]
    public async Task<IActionResult> UpdateAsync([FromForm] CommentDto dto)
    {
        await _commentService.UpdateAsync(dto);
        return Ok();
    }
}
