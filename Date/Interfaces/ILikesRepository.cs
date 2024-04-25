using Domain.Entities;

namespace Date.Interfaces;
public interface ILikesRepository
{
    Task GiveAsync(Likes likes);
    Task DeleteAsync(Likes likes);
    Task<List<Likes>> GetAllAsync();
    Task<Likes> GetByIdAsync(int id);
}
