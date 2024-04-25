using Data.Repositories;
using Date.DbContex;
using Date.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories;
public class AuthorRepository(AppDbContext dbContext) : GenericRepository<Author>(dbContext), IAuthorRepository
{
    public async Task<Author?> GetByNameAsync(string name)
    {
        return await _dbContext.Authors.FirstOrDefaultAsync(c => c.Name == name);
    }
}
