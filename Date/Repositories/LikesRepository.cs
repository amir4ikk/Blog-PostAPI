using Date.DbContex;
using Date.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories;
public class LikesRepository(AppDbContext dbContext) : ILikesRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly DbSet<Likes> _dbSet = dbContext.Set<Likes>();

    public async Task GiveAsync(Likes likes)
    {
        await _dbSet.AddAsync(likes);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Likes likes)
    {
        _dbSet.Remove(likes);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Likes>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<Likes?> GetByIdAsync(int id)
        => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

}
