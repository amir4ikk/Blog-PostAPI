using Domain.Entities;

namespace Application.Dtos.AuthorDtos;
public class AddAuthorDto
{
    public string Name { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;


    public static implicit operator Author(AddAuthorDto dto)
    {
        return new Author
        {
            Name = dto.Name,
            Year = dto.Year,
        };
    }
}
