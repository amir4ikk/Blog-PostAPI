using Application.Dtos.AuthorDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    private readonly IAuthorService _authorService = authorService;

    [HttpPost,Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddAuthorDto dto)
    {
        await _authorService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _authorService.GetAllAsync());
    }

    [HttpGet("{id}"), Authorize]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _authorService.GetByIdAsync(id));
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _authorService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut, Authorize(Roles = "Admin,SuperAdmin")]
    public async Task<IActionResult> UpdateAsync([FromForm]AuthorDto author)
    {
        await _authorService.UpdateAsync(author);
        return Ok();
    }

}
