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

    public async Task<List<Post>> GetAllWithCommentsAndLikesAsync()
    {
        var posts = await _dbContext.Posts.Include(i => i.Comments).Include(i => i.Likes).Include(i => i.Author).ToListAsync();

        return posts;
    }

    public async Task<List<Post>> GetByIdWithCommentsAndLikesAsync(int id)
    {
        var posts = await _dbContext.Posts.Include(i => i.Comment_id).Include(i => i.Likes_id).Include(i => i.Author_id).ToListAsync();

        return posts;
    }

}
