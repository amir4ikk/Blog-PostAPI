using Domain.Entities;
using System.Net;

namespace Date.Interfaces;
public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<Author?> GetByNameAsync(string name);
}
