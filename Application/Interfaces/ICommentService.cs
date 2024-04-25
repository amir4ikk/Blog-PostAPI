using Application.Dtos.CommentDtos;

namespace Application.Interfaces;
public interface ICommentService
{
    Task CreateAsync(AddCommentDto dto);
    Task UpdateAsync(CommentDto dto);
    Task DeleteAsync(int id);
    Task<List<CommentDto>> GetAllAsync();
    Task<CommentDto?> GetByIdAsync(int id);
}
