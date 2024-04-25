using Application.Dtos.PostDtos;

namespace Application.Interfaces;
public interface IPostService
{
    Task CreateAsync(AddPostDto dto);
    Task UpdateAsync(PostDto dto);
    Task DeleteAsync(int id);
    Task<List<PostDto>> GetAllAsync();
    Task<PostDto> GetByIdAsync(int id);
}
