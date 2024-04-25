using Application.Dtos.CommentDtos;
using Domain.Entities;

namespace Application.Dtos.UserDtos;
public class UserDto : AddUserDto
{
    public int Id { get; set; }

    public static implicit operator UserDto(User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Phone_Number = user.Phone_Number
        };
    }

    public static implicit operator User(UserDto dto)
    {
        return new User()
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            Phone_Number = dto.Phone_Number
        };
    }
}
