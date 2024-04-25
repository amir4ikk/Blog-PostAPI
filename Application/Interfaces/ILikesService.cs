using Application.Dtos.LikesDtos;

namespace Application.Interfaces;
public interface ILikesService
{
    Task CreateAsync(AddLikesDto dto);
    Task DeleteAsync(int id);
    Task<List<LikesDto>> GetAllAsync();
}
