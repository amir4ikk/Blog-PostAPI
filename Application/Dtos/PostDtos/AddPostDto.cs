using Domain.Entities;

namespace Application.Dtos.PostDtos;
public class AddPostDto
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Author_id { get; set; }
    public int Created { get; set; }

    public static implicit operator Post(AddPostDto dto)
    {
        return new Post
        {
            Author_id = dto.Author_id,
            Text = dto.Text,
            Created = dto.Created,
            Title = dto.Title,
        };
    }
}
