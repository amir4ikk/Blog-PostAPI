using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.Dtos.PostDtos;
using Application.Interfaces;
using Date.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Net;
using System.Xml.Linq;

namespace Application.Services;
public class PostService(IUnitOfWork unitOfWork,
                          IValidator<Post> validator)
    : IPostService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Post> _validator = validator;

    public async Task CreateAsync(AddPostDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());
        await _unitOfWork.Post.CreateAsync((Post)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var movie = await _unitOfWork.Post.GetByIdAsync(id);
        if (movie is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Post mavjud emas");
        await _unitOfWork.Post.DeleteAsync(movie);
    }

    public async Task<List<PostDto>> GetAllAsync()
    {
        //var posts = await _unitOfWork.Post.GetAllAsync();
        //var authors = await _unitOfWork.Author.GetAllAsync();

        //var entities = new List<PostDto>();

        //foreach (var post in posts)
        //{
        //    var author = authors.First(p => p.Id == post?.Author_id);
        //    var dto = (PostDto)post;
        //    dto.Author = new Author()
        //    {
        //        Id = author.Id,
        //        Name = author.Name,
        //        Year = author.Year,
        //    };

        //    entities.Add(dto);
        //}

        var posts = await _unitOfWork.Post.GetAllWithCommentsAsync();
        return posts.Select(i => (PostDto)i).ToList();
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        var post = await _unitOfWork.Post.GetByIdAsync(id);
        if (post is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Post topilmadi");

        var author = await _unitOfWork.Author.GetByIdAsync(post.Author_id);
        var entity = (PostDto)post;


        entity.Author = new Author()
        {
            Id = author.Id,
            Name = author.Name,
            Year = author.Year,
        };

        return entity;
    }
    public async Task UpdateAsync(PostDto dto)
    {
        var post = await _unitOfWork.Post.GetByIdAsync(dto.Id);
        if (post is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Janr yo'q");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Post.UpdateAsync((Post)dto);
    }
}
