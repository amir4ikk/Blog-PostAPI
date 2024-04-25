using Data.Repositories;
using Date.DbContex;
using Date.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories;
public class CommentRepository(AppDbContext dbContext) : GenericRepository<Comment>(dbContext), ICommentsRepository
{
    public async Task<Comment?> GetByNameAsync(string name)
    {
        return await _dbContext.Comments.FirstOrDefaultAsync(c => c.CommenterName == name);
    }
}