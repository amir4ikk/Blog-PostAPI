using Date.DbContex;
using Date.Interfaces;

namespace Date.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public ICommentsRepository Comments => new CommentRepository(_dbContext);

    public IAuthorRepository Author => new AuthorRepository(_dbContext);

    public ILikesRepository Likes => new LikesRepository(_dbContext);

    public IPostRepository Post => new PostRepository(_dbContext);

    public IUserRepository User => new UserRepository(_dbContext);
}
