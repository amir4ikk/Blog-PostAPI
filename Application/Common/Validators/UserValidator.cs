using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Bosh bolmasligi lozim")
            .Length(3, 50)
            .WithMessage("First Name 3 va 50 orasida bolishi kerak");

        RuleFor(x => x.Email)
             .NotEmpty()
             .WithMessage("Email bosh bolmasligi lozim")
             .Length(3, 50)
             .EmailAddress()
             .WithMessage("Email 3 va 50 orasida bolishi kerak");

        RuleFor(x => x.Password)
             .NotEmpty()
             .WithMessage("Password bosh bolmasligi lozim")
             .Length(6, 16)
             .WithMessage("Password 6 va 16 orasida bolishi kerak");

        RuleFor(x => x.Phone_Number)
            .NotEmpty()
            .WithMessage("Phone Number Bosh bolmasligi lozim")
            .Length(9, 12)
            .WithMessage("Phone Number 9 va 12 orasida bolishi kerak");
    }
}
