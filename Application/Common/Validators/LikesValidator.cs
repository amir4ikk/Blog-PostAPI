using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;
public class LikesValidator : AbstractValidator<Likes>
{
    public LikesValidator()
    {
        RuleFor(x => x.Counter)
            .NotEmpty()
            .WithMessage("Counter bosh bolmasligi lozim")
            .GreaterThan(0)
            .WithMessage("Qiymati 0 dan katta bolishi kerak")
            .LessThan(2)
            .WithMessage("Qiymati 2 dan kichik bolishi kerak");

        RuleFor(x => x.Post_id)
            .GreaterThan(0)
            .WithMessage("Postid 0 bomasligi kerak");

        RuleFor(x => x.User_id)
            .GreaterThan(0)
            .WithMessage("Userid 0 bomasligi kerak");
    }
}
