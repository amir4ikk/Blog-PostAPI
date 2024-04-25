using Application.Dtos.LikesDtos;
using Application.Dtos.UserDtos;

namespace Application.Interfaces;
public interface IUserService
{
    Task CreateAsync(AddUserDto dto);
    Task<UserDto> GetByIdAsync(int id);
    Task<List<UserDto>> GetAllAsync();
    Task UpdateAsync(int id, UpdateUserDto dto);
    Task DeleteAsync(int id);
}
