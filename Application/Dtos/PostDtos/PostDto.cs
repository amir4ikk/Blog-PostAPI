using Application.Dtos.AuthorDtos;
using Application.Dtos.CommentDtos;
using Application.Dtos.LikesDtos;
using Domain.Entities;

namespace Application.Dtos.PostDtos;
public class PostDto : AddPostDto
{
    public int Id { get; set; }
    public List<AuthorDto> Author { get; set; } = null!;
    public List<LikesDto> Likes { get; set; } = null!;
    public List<CommentDto> Comment { get; set; } = null!;

    public static implicit operator PostDto(Post post)
    {
        return new PostDto()
        {
            Id = post.Id,
            Author_id = post.Author_id,
            Text = post.Text,
            Created = post.Created,
            Title = post.Title,
            Comment = post.Comments.Select(i => (CommentDto)i).ToList(),
            Likes = post.Likes.Select(i => (LikesDto)i).ToList(),
            Author = post.Author.Select(i => (AuthorDto)i).ToList(),
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
