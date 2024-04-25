using Application.Dtos.AuthorDtos;
using Domain.Entities;

namespace Application.Dtos.CommentDtos;
public class CommentDto : AddCommentDto
{
    public int Id { get; set; }

    public static implicit operator CommentDto(Comment author)
    {
        return new CommentDto()
        {
            Id = author.Id,
            Description = author.Description,
            Post_id = author.Post_id,
            User_id = author.User_id,
        };
    }

    public static implicit operator Comment(CommentDto dto)
    {
        return new Comment()
        {
            Id = dto.Id,
            Description = dto.Description,
            Post_id = dto.Post_id,
            User_id = dto.User_id,
        };
    }
}
