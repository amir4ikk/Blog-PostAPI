using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.Dtos.LikesDtos;
using Application.Interfaces;
using Date.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;

namespace Application.Services;
public class LikesService(IUnitOfWork unitOfWork,
                          IValidator<Likes> validator)
                        : ILikesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Likes> _validator = validator;

    public async Task CreateAsync(AddLikesDto dto)
    {
        var post = await _unitOfWork.Post.GetByIdAsync(dto.Post_id);
        if (post != null)
            throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "postga oldin like qoyilgan");
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());
        await _unitOfWork.Likes.GiveAsync((Likes)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await _unitOfWork.Likes.GetByIdAsync(id);
        if (genre is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "like yo'q");

        await _unitOfWork.Likes.DeleteAsync(genre);
    }

    public async Task<List<LikesDto>> GetAllAsync()
    {
        var genres = await _unitOfWork.Likes.GetAllAsync();

        return genres.Select(item => (LikesDto)item).ToList();
    }

}
