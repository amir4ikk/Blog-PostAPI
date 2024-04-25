using Domain.Entities;
using Domain.Enums;

namespace Application.Dtos.UserDtos;

public class UpdateUserDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone_Number { get; set; } = string.Empty;

    public static implicit operator User(UpdateUserDto dto)
    {
        return new User()
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            Phone_Number = dto.Phone_Number,
        };
    }
}
