using Domain.Entities;

namespace Date.Interfaces;
public interface ICommentsRepository : IGenericRepository<Comment>
{
    Task<Comment?> GetByNameAsync(string name);
}
