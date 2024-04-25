using Data.Repositories;
using Date.DbContex;
using Date.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories;
public class PostRepository(AppDbContext dbContext) : GenericRepository<Post>(dbContext), IPostRepository
{
    public async Task<List<Post>> GetByNameAsync(string name)
    {
        var posts = await _dbContext.Posts.ToListAsync();

        return posts.Where(p => p.Title.ToLower().Contains(name.ToLower())).ToList();
    }
}
