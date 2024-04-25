using Domain.Entities;

namespace Application.Dtos.PostDtos;
public class PostDto : AddPostDto
{
    public int Id { get; set; }
    public Author Author { get; set; } = null!;
    public Likes Likes { get; set; } = null!;
    public Comment Comment { get; set; } = null!;

    public static implicit operator PostDto(Post post)
    {
        return new PostDto()
        {
            Id = post.Id,
            Author_id = post.Author_id,
            Text = post.Text,
            Created = post.Created,
            Title = post.Title,
        };
    }

    public static implicit operator Post(PostDto dto)
    {
        return new Post()
        {
            Id = dto.Id,
            Author_id = dto.Author_id,
            Text = dto.Text,
            Created = dto.Created,
            Title = dto.Title,
        };
    }
}
