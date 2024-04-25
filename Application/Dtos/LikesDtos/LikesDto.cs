using Application.Dtos.CommentDtos;
using Domain.Entities;

namespace Application.Dtos.LikesDtos;
public class LikesDto : AddLikesDto
{
    public int Id { get; set; }

    public static implicit operator LikesDto(Likes likes)
    {
        return new LikesDto()
        {
            Id = likes.Id,
            Counter = likes.Counter,
            Post_id = likes.Post_id,
            User_id = likes.User_id,
        };
    }

    public static implicit operator Likes(LikesDto dto)
    {
        return new Likes()
        {
            Id = dto.Id,
            Counter = dto.Counter,
            Post_id = dto.Post_id,
            User_id = dto.User_id,
        };
    }
}
