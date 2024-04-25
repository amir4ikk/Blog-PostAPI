namespace Date.Interfaces;
public interface IUnitOfWork
{
    ICommentsRepository Comments { get; }
    IAuthorRepository Author { get; }
    ILikesRepository Likes { get; }
    IPostRepository Post { get; }
    IUserRepository User { get; }
}
