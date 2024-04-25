using Domain.Entities;

namespace Date.Interfaces;
public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> GetByNameAsync(string name);
    Task<List<Post>> GetAllWithCommentsAsync();
}
