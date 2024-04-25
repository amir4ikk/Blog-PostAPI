using Domain.Entities;

namespace Application.Dtos.LikesDtos;
public class AddLikesDto
{
    public int Counter { get; set; }
    public int Post_id { get; set; }
    public int User_id { get; set; }

    public static implicit operator Likes(AddLikesDto dto)
    {
        return new Likes
        {
            Counter = dto.Counter,
            Post_id = dto.Post_id,
            User_id = dto.User_id,
        };
    }
}
