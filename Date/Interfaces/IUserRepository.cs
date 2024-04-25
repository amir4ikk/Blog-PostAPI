using Domain.Entities;

namespace Date.Interfaces;
public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string name);
}
