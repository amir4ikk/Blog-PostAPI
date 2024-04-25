using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.Dtos.CommentDtos;
using Application.Interfaces;
using Date.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;
using System.Runtime.InteropServices;

namespace Application.Services;
public class CommentService(IUnitOfWork unitOfWork,
                          IValidator<Comment> validator)
                        : ICommentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Comment> _validator = validator;

    public async Task CreateAsync(AddCommentDto dto)
    {
        var genre = await _unitOfWork.Comments.GetByNameAsync(dto.CommenterName);
        if (genre != null)
            throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "comment oldin foydalanilgan");
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Comments.CreateAsync((Comment)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await _unitOfWork.Comments.GetByIdAsync(id);
        if (genre is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "comment yo'q");

        await _unitOfWork.Comments.DeleteAsync(genre);
    }

    public async Task<List<CommentDto>> GetAllAsync()
    {
        var genres = await _unitOfWork.Comments.GetAllAsync();

        return genres.Select(item => (CommentDto)item).ToList();
    }

    public async Task<CommentDto?> GetByIdAsync(int id)
    {
        var genre = await _unitOfWork.Comments.GetByIdAsync(id);
        if (genre is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "comment mavjud emas");

        return (CommentDto)genre;
    }

    public async Task UpdateAsync(CommentDto dto)
    {
        var genre = await _unitOfWork.Comments.GetByIdAsync(dto.Id);
        if (genre is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "comment yo'q");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Comments.UpdateAsync((Comment)dto);
    }
}
