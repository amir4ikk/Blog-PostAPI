using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("あなたはクソビッチですか？")
            .Length(3, 50)
            .WithMessage("名は 3 ～ 50 の間で指定する必要があります");

        RuleFor(x => x.Email)
             .NotEmpty()
             .WithMessage("メールは送信してはいけません")
             .Length(3, 50)
             .EmailAddress()
             .WithMessage("メールアドレスは 3 ～ 50 である必要があります");

        RuleFor(x => x.Password)
             .NotEmpty()
             .WithMessage("Password bosh bolmasligi lozim")
             .Length(6, 16)
             .WithMessage("Password 6 va 16 orasida bolishi kerak");

        RuleFor(x => x.Phone_Number)
            .NotEmpty()
            .WithMessage("Phone Number Bosh bolmasligi lozim")
            .Length(9, 12)
            .WithMessage("Phone Number 10 va 15 orasida bolishi kerak");
    }
}
