using Application.Dtos.PostDtos;
using Domain.Entities;

namespace Application.Dtos.CommentDtos;
public class AddCommentDto
{
    public string CommenterName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Post_id { get; set; }
    public int User_id { get; set; }

    public static implicit operator Comment(AddCommentDto dto)
    {
        return new Comment
        {
            CommenterName = dto.CommenterName,
            Description = dto.Description,
            Post_id = dto.Post_id,
            User_id = dto.User_id,
            Post = null
        };
    }
}
