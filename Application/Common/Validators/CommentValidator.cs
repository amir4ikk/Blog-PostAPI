using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;
public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(x => x.CommenterName)
            .NotEmpty()
            .WithMessage("Commentator Name Bosh Bolmasligi Lozim");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description bosh bolmasligi kerak")
            .MinimumLength(5)
            .WithMessage("Kamida 5ta belgi bolishi kerak");

        RuleFor(x => x.Post_id)
            .GreaterThan(0)
            .WithMessage("Postid 0 bomasligi kerak");

        RuleFor(x => x.User_id)
            .GreaterThan(0)
            .WithMessage("Userid 0 bomasligi kerak");
    }
}
