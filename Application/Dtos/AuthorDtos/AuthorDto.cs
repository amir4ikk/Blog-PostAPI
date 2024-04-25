using Domain.Entities;

namespace Application.Dtos.AuthorDtos;
public class AuthorDto : AddAuthorDto
{
    public int Id { get; set; }

    public static implicit operator AuthorDto(Author author)
    {
        return new AuthorDto()
        {
            Id = author.Id,
            Name = author.Name,
            Year = author.Year,
        };
    }

    public static implicit operator Author(AuthorDto dto)
    {
        return new Author()
        {
            Id = dto.Id,
            Name = dto.Name,
            Year = dto.Year,
        };
    }
}
