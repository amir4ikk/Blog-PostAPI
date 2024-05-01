using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;
public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name bolmasligi lozim")
            .Length(3, 50)
            .WithMessage("Name 3 va 50 orasida bolishi kerak");

        RuleFor(x => x.Year)
            .NotEmpty()
            .WithMessage("Year bosh bolmasligi lozim")
            .Length(4)
            .WithMessage("Year 4 tadan iborat bolishi kerak");
    }
}
