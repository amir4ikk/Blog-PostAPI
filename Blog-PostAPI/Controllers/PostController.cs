using Application.Dtos.PostDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController(IPostService postService) : ControllerBase
{
    private readonly IPostService _postService = postService;

    [HttpPost]
    //[Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> CreateAsync([FromForm]AddPostDto dto)
    {
        await _postService.CreateAsync(dto);
        return Ok();
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id) 
    {
        return Ok(await _postService.GetByIdAsync(id));
    }

    [HttpGet("Post")]
    //[Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _postService.GetAllAsync());
    }

    [HttpDelete("id")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _postService.DeleteAsync(id);
        return Ok();
    }
    
}
