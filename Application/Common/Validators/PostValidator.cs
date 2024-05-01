using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;
public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title bosh bolmasligi kerak")
            .Length(3, 40)
            .WithMessage("Title 3 va 40 belgi orasida bolishi kerak");

        RuleFor(x => x.Created)
            .ExclusiveBetween(2000, DateTime.UtcNow.Year)
            .WithMessage($"Year 2000 va {DateTime.UtcNow.Year} yil orasida bolishi kerak");

        RuleFor(x => x.Author_id)
            .GreaterThan(0)
            .WithMessage("Author id 0 bomasligi kerak");

        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Text bosh bolmasligi kerak")
            .MinimumLength(20)
            .WithMessage("Kamida 20ta belgi bolishi kerak");
    }
}
