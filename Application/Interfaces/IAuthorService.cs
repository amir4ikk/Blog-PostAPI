using Application.Dtos.AuthorDtos;
using Application.Dtos.PostDtos;

namespace Application.Interfaces;
public interface IAuthorService
{
    Task CreateAsync(AddAuthorDto dto);
    Task UpdateAsync(AuthorDto author);
    Task DeleteAsync(int id);
    Task<List<AuthorDto>> GetAllAsync();
    Task<AuthorDto?> GetByIdAsync(int id);
}
