using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.Dtos.AuthorDtos;
using Application.Dtos.PostDtos;
using Application.Interfaces;
using Date.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;

namespace Application.Services;
public class AuthorService(IUnitOfWork unitOfWork,
                          IValidator<Author> validator)
                        : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Author> _validator = validator;

    public async Task CreateAsync(AddAuthorDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Author.CreateAsync((Author)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var Aftor = await _unitOfWork.Author.GetByIdAsync(id);
        if (Aftor is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Author yo'q");

        await _unitOfWork.Author.DeleteAsync(Aftor);
    }

    public async Task<List<AuthorDto>> GetAllAsync()
    {
        var Aftor = await _unitOfWork.Author.GetAllAsync();

        return Aftor.Select(item => (AuthorDto)item).ToList();
    }

    public async Task<AuthorDto?> GetByIdAsync(int id)
    {
        var Aftor = await _unitOfWork.Author.GetByIdAsync(id);
        if (Aftor is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Author mavjud emas");

        return (AuthorDto)Aftor;
    }

    public async Task UpdateAsync(AuthorDto author)
    {
        var Aftor = await _unitOfWork.Author.GetByIdAsync(author.Id);
        if (Aftor is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Author yo'q");

        await _unitOfWork.Author.UpdateAsync((Author)author);   
    }
}
