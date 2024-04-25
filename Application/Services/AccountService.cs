using Application.Common.Exceptions;
using Application.Common.Security;
using Application.Common.Validators;
using Application.Dtos.UserDtos;
using Application.Interfaces;
using Date.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;


namespace Application.Services;

public class AccountService(IUnitOfWork ofWork,
                            IAuthManager authManager,
                            IValidator<User> validator)
    : IAccountService
{

    private readonly IAuthManager _auth = authManager;

    private readonly IUnitOfWork _UnitOfWork = ofWork;
    private readonly IValidator<User> _validator = validator;

    public async Task<string> LoginAsync(LoginDto login)
    {
        var user = await _UnitOfWork.User.GetByEmailAsync(login.Email);

        if (user is null) throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        if (user.Password.Equals(PasswordHasher.GetHash(login.Password)))
            throw new StatusCodeExeption(HttpStatusCode.Conflict, "Password incorrect!");

        return _auth.GeneratedToken(user);
    }

    public async Task<bool> RegistrAsync(AddUserDto dto)
    {
        var user = await _UnitOfWork.User.GetByEmailAsync(dto.Email);

        if (user is not null) throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "User already exists!");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        var entity = (User)dto;
        entity.Password = PasswordHasher.GetHash(entity.Password);

        await _UnitOfWork.User.CreateAsync(entity);

        return true;
    }
}
