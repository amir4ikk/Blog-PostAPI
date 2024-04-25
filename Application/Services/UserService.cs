using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.Dtos.UserDtos;
using Application.Interfaces;
using Date.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;

namespace Application.Services;
public class UserService(IUnitOfWork unitOfWork,
                         IValidator<User> validator)
                        : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<User> _validator = validator;

    public async Task CreateAsync(AddUserDto dto)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(dto.Email);
        if (user != null)
            throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "Bunday User Bor");
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());
        await _unitOfWork.User.CreateAsync((User)dto);
    }
    public async Task DeleteAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");
        await _unitOfWork.User.DeleteAsync(user);
        throw new StatusCodeExeption(HttpStatusCode.OK, "User has been deleted sucessfully");
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.User.GetAllAsync();
        return users.Select(x => (UserDto)x).ToList();
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");
        return (UserDto)user;
    }

    public async Task UpdateAsync(int id, UpdateUserDto dto)
    {
        var model = await _unitOfWork.User.GetByIdAsync(id);
        if (model is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");
        var user = (User)dto;
        user.Id = id;
        user.Password = model.Password;

        await _unitOfWork.User.UpdateAsync(user);
        throw new StatusCodeExeption(HttpStatusCode.OK, "User has been updated sucessfully");
    }
}