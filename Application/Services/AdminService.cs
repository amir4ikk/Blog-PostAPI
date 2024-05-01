using Application.Common.Exceptions;
using Application.Interfaces;
using Date.Interfaces;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using System.Net;

namespace Application.Services;

public class AdminService(IUnitOfWork work,
                          IValidator<User> validator) : IAdminService
{
    private readonly IUnitOfWork _work = work;
    private readonly IValidator<User> _validator = validator;

    public async Task ChangeUserRoleAsync(int id)
    {
        var user = await _work.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        if (user.Role == Roles.SuperAdmin)
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "Are You Serius?");

        user.Role = user.Role == Roles.Admin ? Roles.User : Roles.Admin;

        await _work.User.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _work.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        await _work.User.DeleteAsync(user);
    }

    public async Task<List<User>> GetAllAdminAsync()
        => (await _work.User.GetAllAsync())
            .Where(p => p.Role == Roles.Admin)
            .ToList();
}
